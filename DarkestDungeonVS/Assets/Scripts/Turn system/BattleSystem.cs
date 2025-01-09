using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

    public Color CurrentTurnColor = Color.yellow;

    [SerializeField] List<BattleState> visitedStates = new List<BattleState>();



    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        Debug.Log("Battle START!");
        triggerDamageScript = FindAnyObjectByType<TriggerDamageScript>();
        SpawnPrefabs();


    }

    private void Update()
    {
        HighlightTurn(BattleState.ALLY1, 0, InstantiatedAllies);
        HighlightTurn(BattleState.ALLY2, 1, InstantiatedAllies);
        HighlightTurn(BattleState.ALLY3, 2, InstantiatedAllies);
        HighlightTurn(BattleState.ALLY4, 3, InstantiatedAllies);
        HighlightTurn(BattleState.ENEMY1, 0, InstantiatedEnemies);
        HighlightTurn(BattleState.ENEMY2, 1, InstantiatedEnemies);
        HighlightTurn(BattleState.ENEMY3, 2, InstantiatedEnemies);
    }


    public void BattleStateSwitch()
    {
        // Add the current state to the visited list if it's not already there
        if (!visitedStates.Contains(state))
        {
            visitedStates.Add(state);
        }

        // Find the next state that has not been visited
        BattleState nextState = GetNextUnvisitedState();

        // If all states have been visited, reset for the next round
        if (nextState == BattleState.START)
        {
            visitedStates.Clear();
            nextState = BattleState.ALLY1; // Start a new round with ALLY1
        }

        state = nextState;
    }

    public BattleState GetNextUnvisitedState()
    {
        BattleState[] allStates = {
        BattleState.ALLY1, BattleState.ALLY3, BattleState.ALLY4, BattleState.ENEMY2, BattleState.ALLY2,
        BattleState.ENEMY1, BattleState.ENEMY3
    };

        foreach (BattleState potentialState in allStates)
        {
            if (!visitedStates.Contains(potentialState))
            {
                return potentialState;
            }
        }

        // Return START to indicate all states have been visited
        return BattleState.START;
    }


    void SpawnPrefabs()
    {
        // Ensure no errors occur if lists are uneven
        int allyCount = Mathf.Min(Allies.Count, SpawnPointAllies.Count);
        int enemyCount = Mathf.Min(Enemies.Count, SpawnPointEnemies.Count);

        // Instantiate Allies
        for (int i = 0; i < allyCount; i++)
        {
            if (Allies[i] != null && i < SpawnPointAllies.Count)
            {
                Vector2 spawnPosition = SpawnPointAllies[i];
                GameObject newAlly = Instantiate(Allies[i], spawnPosition, Quaternion.identity);
                var mouseClick = newAlly.GetComponent<MouseClick>();
                if (mouseClick != null)
                {
                    triggerDamageScript.AddAlly(mouseClick); // Add MouseClick to TriggerDamageScript
                    Debug.Log($"Ally {i + 1} instantiated at {spawnPosition}");
                }
                else
                {
                    Debug.LogError($"Spawned ally at {spawnPosition} is missing a MouseClick component!");
                }
                InstantiatedAllies.Add(newAlly); // Add to the list of instantiated allies
            }
            else
            {
                Debug.LogWarning($"Ally {i + 1} or its spawn point is missing!");
            }
        }

        // Instantiate Enemies
        for (int i = 0; i < enemyCount; i++)
        {
            if (Enemies[i] != null && i < SpawnPointEnemies.Count)
            {
                Vector2 spawnPosition = SpawnPointEnemies[i];
                GameObject newEnemy = Instantiate(Enemies[i], spawnPosition, Quaternion.identity);
                var mouseClick = newEnemy.GetComponent<MouseClick>();
                if (mouseClick != null)
                {
                    triggerDamageScript.AddAlly(mouseClick); // Add MouseClick to TriggerDamageScript
                    Debug.Log($"Enemy {i + 1} instantiated at {spawnPosition}");
                }
                else
                {
                    Debug.LogError($"Spawned enemy at {spawnPosition} is missing a MouseClick component!");
                }
                InstantiatedEnemies.Add(newEnemy); // Add to the list of instantiated enemies
            }
            else
            {
                Debug.LogWarning($"Enemy {i + 1} or its spawn point is missing!");
            }
        }
    }



    //if statements om te zien wie er aan de beurt is (turn highlight), later binden aan een cursor 
    private void HighlightTurn(BattleState currentState, int index, List<GameObject> entities)
    {
        if (index >= 0 && index < entities.Count && entities[index] != null)
        {
            GameObject entity = entities[index];
            entity.GetComponent<SpriteRenderer>().color = (state == currentState) ? Color.yellow : Color.white;
        }
    }

}
