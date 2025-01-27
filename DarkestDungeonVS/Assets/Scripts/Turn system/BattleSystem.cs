using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum BattleState { START, ALLY1, ALLY2, ALLY3, ALLY4, ENEMY1, ENEMY2, ENEMY3, WIN, LOSE };

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public static Action NextTurn;

    private TriggerDamageScript triggerDamageScript;

    [SerializeField] List<GameObject> Allies = new List<GameObject>();
    [SerializeField] List<GameObject> Enemies = new List<GameObject>();

    [SerializeField] List<GameObject> InstantiatedAllies = new List<GameObject>();
    [SerializeField] List<GameObject> InstantiatedEnemies = new List<GameObject>();

    [SerializeField] List<Vector2> SpawnPointAllies = new List<Vector2>();
    [SerializeField] List<Vector2> SpawnPointEnemies = new List<Vector2>();

    [SerializeField] List<GameObject> BattleStateIndicators = new List<GameObject>();

    [SerializeField] List<GameObject> UIHeroes = new List<GameObject>();

    public Color CurrentTurnColor = Color.yellow;

    [SerializeField] List<BattleState> visitedStates = new List<BattleState>();

    private TMP_Text TextField;  // References to the TMP_Text component

    public GameObject EndButtons;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        Debug.Log("Battle START!");
        triggerDamageScript = FindAnyObjectByType<TriggerDamageScript>();
        SpawnPrefabs();
        EndButtons.SetActive(false);

        if (TextField == null)
        {
            TextField = GameObject.Find("EndText")?.GetComponent<TMP_Text>();
            if (TextField == null)
            {
                Debug.LogError("TextField is not assigned! Ensure a TMP_Text component is named 'EndText' or assigned in the Inspector.");
            }
        }
        // Ensure the indicators list is populated for each state
        if (BattleStateIndicators.Count != Enum.GetValues(typeof(BattleState)).Length)
        {
            Debug.LogError("Ensure BattleStateIndicators list matches the number of BattleStates!");
        }
        // Ensure the UI part of the heroes to each state
        if (UIHeroes.Count != Enum.GetValues(typeof(BattleState)).Length)
        {
            Debug.LogError("Ensure UIHeroes list matches the number of BattleStates!");
        }
    }

    private void Update()
    {
        UpdateHeroesUI();

        UpdateIndicators();

        HighlightTurn(BattleState.ALLY1, 0, InstantiatedAllies);
        HighlightTurn(BattleState.ALLY2, 1, InstantiatedAllies);
        HighlightTurn(BattleState.ALLY3, 2, InstantiatedAllies);
        HighlightTurn(BattleState.ALLY4, 3, InstantiatedAllies);
        HighlightTurn(BattleState.ENEMY1, 0, InstantiatedEnemies);
        HighlightTurn(BattleState.ENEMY2, 1, InstantiatedEnemies);
        HighlightTurn(BattleState.ENEMY3, 2, InstantiatedEnemies); 

        SpriteAttackEnemies(BattleState.ENEMY1, 0, InstantiatedEnemies);
        SpriteAttackEnemies(BattleState.ENEMY2, 1, InstantiatedEnemies);
        SpriteAttackEnemies(BattleState.ENEMY3, 2, InstantiatedEnemies); 

        if (state == BattleState.START)
        {
            StartCoroutine(DelayAndSwitchState());
            return;
        }

        // Prevent further state changes after WIN or LOSE
        if (state == BattleState.WIN || state == BattleState.LOSE)
        {
            TextField.text = $"YOU {state} <br><br>Thanks for playing our demo! If you want you can play again or just quit.";
            EndButtons.SetActive(true); // Enable the buttons
            Debug.Log($"Game Over: {state}");
            return; // No more state transitions after the game ends
        }

        // Check for WIN or LOSE condition before switching the state
        if (IsAlliesDefeated())
        {
            Debug.Log("All allies are defeated. YOU LOSE!");
            state = BattleState.LOSE;
            return; // Early exit if the game is over
        }
        else if (IsEnemiesDefeated())
        {
            Debug.Log("All enemies are defeated. YOU WIN!");
            state = BattleState.WIN;
            return; // Early exit if the game is over
        }
    }

    public void BattleStateSwitch()
    {


        // Proceed with the normal state switching
        if (!visitedStates.Contains(state))
        {
            visitedStates.Add(state);
        }

        BattleState nextState = GetNextValidUnvisitedState();

        if (nextState == BattleState.START)
        {
            visitedStates.Clear();
            GetNextValidUnvisitedState();
        }

        // If the current state is START, wait before moving to the next state
        if (state == BattleState.START)
        {
            StartCoroutine(DelayAndSwitchState());  
            return;
        }

        state = nextState;

        if (state.ToString().StartsWith("ENEMY"))
        {
            // Trigger auto-attack for enemy turns
            StartCoroutine(EnemyAttack());
        }
    }

    private bool IsAlliesDefeated()
    {
        // Check if there are no active allies left
        return InstantiatedAllies.FindAll(ally => ally != null && ally.activeInHierarchy).Count == 0;
    }

    private bool IsEnemiesDefeated()
    {
        // Get count of active enemies
        int activeEnemiesCount = InstantiatedEnemies.FindAll(enemy => enemy != null && enemy.activeInHierarchy).Count;
        Debug.Log($"Active enemies remaining: {activeEnemiesCount}"); // Debug log
        return activeEnemiesCount == 0; // Return true if no active enemies
    }


    // Coroutine to handle the delay and then switch to the next valid state
    private IEnumerator DelayAndSwitchState()
    {
        yield return new WaitForSeconds(1.0f); // Wait for 1 second

        BattleState nextState = GetNextValidUnvisitedState();

        if (nextState == BattleState.START)
        {
            visitedStates.Clear();
            nextState = BattleState.ALLY1; // Start a new round
        }

        state = nextState;

        if (state.ToString().StartsWith("ENEMY"))
        {
            // Trigger auto-attack for enemy turns
            StartCoroutine(EnemyAttack());
        }
    }

    private BattleState GetNextValidUnvisitedState()
    {
        BattleState[] allStates = {
            BattleState.ALLY1, BattleState.ALLY3, BattleState.ALLY4, BattleState.ENEMY2, BattleState.ALLY2,
            BattleState.ENEMY1, BattleState.ENEMY3
        };

        foreach (BattleState potentialState in allStates)
        {
            if (!visitedStates.Contains(potentialState) && IsStateValid(potentialState))
            {
                return potentialState;
            }
        }

        // Return START to indicate all states have been visited
        return BattleState.START;
    }

    private bool IsStateValid(BattleState stateToCheck)
    {
        if (stateToCheck.ToString().StartsWith("ALLY"))
        {
            int index = stateToCheck - BattleState.ALLY1; // Get index of the ally
            return index >= 0 && index < InstantiatedAllies.Count && InstantiatedAllies[index] != null;
        }
        else if (stateToCheck.ToString().StartsWith("ENEMY"))
        {
            int index = stateToCheck - BattleState.ENEMY1; // Get index of the enemy
            return index >= 0 && index < InstantiatedEnemies.Count && InstantiatedEnemies[index] != null;
        }

        return false; // Default: Invalid state
    }
    private List<GameObject> existingAllies = new List<GameObject>();

    public List<GameObject> ExiastingAllies { get { return existingAllies; } }

    private List<GameObject> existingEnemies = new List<GameObject>();

    public List<GameObject> ExiastingEnemies { get { return existingEnemies; } }

    void SpawnPrefabs()
    {
        for (int i = 0; i < Mathf.Min(Allies.Count, SpawnPointAllies.Count); i++)
        {
            Vector2 spawnPosition = SpawnPointAllies[i];
            GameObject newAlly = Instantiate(Allies[i], spawnPosition, Quaternion.identity);

            existingAllies.Add(newAlly);

            var mouseClick = newAlly.GetComponent<MouseClick>();
            if (mouseClick != null)
            {
                triggerDamageScript.AddAlly(mouseClick);
            }
            InstantiatedAllies.Add(newAlly);
        }

        for (int i = 0; i < Mathf.Min(Enemies.Count, SpawnPointEnemies.Count); i++)
        {
            Vector2 spawnPosition = SpawnPointEnemies[i];
            GameObject newEnemy = Instantiate(Enemies[i], spawnPosition, Quaternion.identity);

            existingEnemies.Add(newEnemy);


            var mouseClick = newEnemy.GetComponent<MouseClick>();
            if (mouseClick != null)
            {
                triggerDamageScript.AddEnemy(mouseClick);
            }
            InstantiatedEnemies.Add(newEnemy);
        }
    }

    private void HighlightTurn(BattleState currentState, int index, List<GameObject> entities)
    {
        if (index >= 0 && index < entities.Count && entities[index] != null)
        {
            GameObject entity = entities[index];
            entity.GetComponent<SpriteRenderer>().color = (state == currentState) ? Color.yellow : Color.white;
        }
    }

    /* private void SpriteAttackEnemies(BattleState currentState, int index, List<GameObject> entities)
     {
         if (index >= 0 && index < entities.Count && entities[index] != null)
         {
             GameObject entity = entities[index];

             // Get all SpriteRenderer components in the entity and its children
             SpriteRenderer[] spriteRenderers = entity.GetComponentsInChildren<SpriteRenderer>();

             if (spriteRenderers.Length > 1) // Ensure there are multiple SpriteRenderers
             {
                 SpriteRenderer defaultSprite = spriteRenderers[1]; // Assume first is default
                 SpriteRenderer attackSprite = spriteRenderers[2];  // Assume second is attack

                 if (state == currentState)
                 {
                     // Enable the attack sprite and disable the default sprite
                     defaultSprite.enabled = false;
                     attackSprite.enabled = true;
                 }
                 else
                 {
                     // Revert to default sprite
                     defaultSprite.enabled = true;
                     attackSprite.enabled = false;
                 }
             }
         } 
     } */

    private void SpriteAttackEnemies(BattleState currentState, int index, List<GameObject> entities)
    {
        if (index >= 0 && index < entities.Count && entities[index] != null)
        {
            GameObject entity = entities[index];

            // Find SpriteRenderer components explicitly
            SpriteRenderer defaultSprite = entity.transform.Find("DefaultSprite")?.GetComponent<SpriteRenderer>();
            SpriteRenderer attackSprite = entity.transform.Find("AttackSprite")?.GetComponent<SpriteRenderer>();

            if (defaultSprite != null && attackSprite != null)
            {
                if (state == currentState)
                {
                    // Enable the attack sprite and disable the default sprite
                    defaultSprite.enabled = false;
                    attackSprite.enabled = true;
                }
                else
                {
                    // Revert to default sprite
                    defaultSprite.enabled = true;
                    attackSprite.enabled = false;
                }
            }
            else
            {
                Debug.LogWarning($"SpriteRenderers not properly assigned for {entity.name}");
            }
        }
    }


    private IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1.0f); // Simulate delay before the enemy attacks

        // Determine which enemy is taking the turn
        int enemyIndex = state - BattleState.ENEMY1;
        if (enemyIndex >= 0 && enemyIndex < InstantiatedEnemies.Count)
        {
            GameObject activeEnemy = InstantiatedEnemies[enemyIndex];

            if (activeEnemy != null)
            {
                // Select a random ally to attack
                GameObject targetAlly = GetRandomAlly();

                if (targetAlly != null)
                {
                    // Perform damage on the target ally
                    DamageSystem damageSystem = activeEnemy.GetComponent<DamageSystem>();
                    if (damageSystem != null)
                    {
                        damageSystem.DamageTarget(targetAlly);
                        
                        Debug.Log($"{activeEnemy.name} attacked {targetAlly.name}!");
                    }
                }
                else
                {
                    Debug.Log($"{activeEnemy.name} has no valid ally to attack.");
                }
            }
        }

        // Move to the next turn after the enemy attack
        BattleStateSwitch();
    }

    // Method to get a random ally that is still alive
    private GameObject GetRandomAlly()
    {
        // Filter out dead allies from the list
        List<GameObject> validAllies = InstantiatedAllies.FindAll(ally => ally != null && ally.activeInHierarchy);

        if (validAllies.Count > 0)
        {
            // Return a random valid ally
            return validAllies[UnityEngine.Random.Range(0, validAllies.Count)];
        }

        return null; // No valid allies left
    }
    private void UpdateIndicators()
    {
        // Iterate through all indicators and update their appearance
        for (int i = 0; i < BattleStateIndicators.Count; i++)
        {
            if (BattleStateIndicators[i] != null)
            {
                // Highlight the current state indicator, reset others
                BattleStateIndicators[i].SetActive((BattleState)i == state);
            }
        }
    }

    private void UpdateHeroesUI()
    {
        for (int i = 0; i < UIHeroes.Count; i++)
        {
            if (state == BattleState.ENEMY2 || state == BattleState.ENEMY1 || state == BattleState.ENEMY3 || state == BattleState.START)
            {
                break;
            }
            if (UIHeroes[i] != null)
            {
                UIHeroes[i].SetActive((BattleState)i == state);
            }
        }
    }
}
