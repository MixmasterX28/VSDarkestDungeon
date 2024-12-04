using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, ALLY1, ALLY2, ALLY3, ALLY4, ENEMY1, ENEMY2, ENEMY3, WIN, LOSE };

public class BattleSystem : MonoBehaviour
{
    
    public BattleState state;

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
        TurnStart(0);
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
    void TurnStart(int index)
    {
        state = BattleState.ALLY1;

        if(state == BattleState.ALLY1 && index >= 0 && index < InstantiatedAllies.Count && InstantiatedAllies[index] != null)
        {
            GameObject changeInstantie = InstantiatedAllies[index];
            changeInstantie.GetComponent<SpriteRenderer>().color = Color.red;
        }

       // if (index >= 0 && index < InstantiatedAllies.Count && InstantiatedAllies[index] != null)
       //{
         //   GameObject changeInstantie = InstantiatedAllies[index];
         //  changeInstantie.GetComponent<SpriteRenderer>().color = Color.red;
        //}

        //Ally1Turn.transform.localScale= new Vector2(1.2f,1.2f);
 
        
    }    
}
