using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum BattleState { START, ALLY1, ALLY2, ALLY3, ALLY4, ENEMY1, ENEMY2, ENEMY3, WIN, LOSE };

public class BattleSystem : MonoBehaviour
{
    
    public BattleState state;

    public static Action NextTurn;

    [SerializeField] List<GameObject> Allies = new List<GameObject>();
    [SerializeField] List<GameObject> Enemies = new List<GameObject>();

    private List<GameObject> InstantiatedAllies = new List<GameObject>();

    [SerializeField] List<Vector2> SpawnPointAllies = new List<Vector2>();
    [SerializeField] List<Vector2> SpawnPointEnemies = new List<Vector2>();

    public Color CurrentTurnColor = Color.yellow;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        Debug.Log("Battle START!");
        SpawnPrefabs();
    }

    private void Update()
    {
        Turn1(0);
        Turn2(1);
        Turn3(2);
        Turn4(3);
    }

   public void BattleStateSwitch()
    {
        switch (state)
        {
            case BattleState.START:
                state = BattleState.ALLY1;
                break;
            case BattleState.ALLY1:
                state = BattleState.ALLY2;
                break;
            case BattleState.ALLY2:
                state = BattleState.ALLY3;  
                break;
            case BattleState.ALLY3:
                state = BattleState.ALLY4;
                break;
            case BattleState.ALLY4:
                state = BattleState.ENEMY1;
                break;
            case BattleState.ENEMY1:
                state = BattleState.ENEMY2;
                break;
            case BattleState.ENEMY2:
                state = BattleState.ENEMY3;
                break;
            case BattleState.ENEMY3:
                state = BattleState.START;
                break;
            case BattleState.WIN:
                break;
            case BattleState.LOSE:
                break;
            default:
                break;
        }
        }

    void SpawnPrefabs()
    {
        //zorgt ervoor dat de loop geen error geeft als de lists niet even groot zijn
        int allyCount = Mathf.Min(Allies.Count, SpawnPointAllies.Count);
        int enemyCount = Mathf.Min(Enemies.Count, SpawnPointEnemies.Count);

        // Instantiate Allies
        for (int i = 0; i < allyCount; i++)
        {
            if (Allies[i] != null && i < SpawnPointAllies.Count)
            {
                Vector2 spawnPosition = SpawnPointAllies[i];
                GameObject newAlly = Instantiate(Allies[i], spawnPosition, Quaternion.identity);
                InstantiatedAllies.Add(newAlly);
                Debug.Log($"Ally {i + 1} instantiated at {spawnPosition}");
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
                Debug.Log($"Enemy {i + 1} instantiated at {spawnPosition}");
            }
            else
            {
                Debug.LogWarning($"Enemy {i + 1} or its spawn point is missing!");
            }
        }
    }


    //if statements om te zien wie er aan de beurt is (turn highlight), later binden aan een cursor 
    void Turn1(int index)
    {
        if(state == BattleState.ALLY1 && index >= 0 && index < InstantiatedAllies.Count && InstantiatedAllies[index] != null)
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }    

    void Turn2(int index)
    {
        if (state == BattleState.ALLY2 && index >= 0 && index < InstantiatedAllies.Count && InstantiatedAllies[index] != null)
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    void Turn3(int index)
    {
        if (state == BattleState.ALLY3 && index >= 0 && index < InstantiatedAllies.Count && InstantiatedAllies[index] != null)
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void Turn4(int index)
    {
        if (state == BattleState.ALLY4 && index >= 0 && index < InstantiatedAllies.Count && InstantiatedAllies[index] != null)
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
