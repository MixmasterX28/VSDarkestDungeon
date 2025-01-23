using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TurnIndicator : MonoBehaviour
{
  

    //[SerializeField] List<Indicators> visitedStates = new List<Indicators>();
    [SerializeField] List<GameObject> Indicator = new List<GameObject>();
    [SerializeField] List<Vector2> SpawnIndicator = new List<Vector2>();

    public GameObject indicatorPrefab;  // Reference to the indicator prefab
    GameObject newIndicator;

    // Start is called before the first frame update
    void Start()
    {

        BattleSystem.OnStateChange += HandleStateChange;

    }

    void OnDestroy()
    {
        BattleSystem.OnStateChange -= HandleStateChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetIndicatorPosition(BattleState state)
    {
        switch (state)
        {
            case BattleState.ALLY1: return new Vector3((float)-8.32, -2f, 0);
            case BattleState.ALLY2: return new Vector3((float)-6.48, -2f, 0);
            case BattleState.ALLY3: return new Vector3((float)-4.58, -2f, 0);
            case BattleState.ALLY4: return new Vector3((float)-2.48, -2f, 0);
            case BattleState.ENEMY1: return new Vector3((float)2.43, -2f, 0);
            case BattleState.ENEMY2: return new Vector3((float)4.98, -2f, 0);
            case BattleState.ENEMY3: return new Vector3((float)7.28, -2f, 0);
            default: return Vector3.zero;
        }
    }

    private void HandleStateChange( BattleState state) {
        //moet iets doen

        Destroy(newIndicator);

        if (state == BattleState.START)
        {
            Debug.Log("Indicator 1 Summoned!");
        }
       if (state == BattleState.ALLY1)
        {
            Debug.Log("Indicator 2 Summoned!");
            newIndicator = Instantiate(indicatorPrefab);
        }
        if (state == BattleState.ALLY2) 
        {
            Debug.Log("Indicator 3 Summoned!");
            newIndicator = Instantiate(indicatorPrefab);
        }
        if (state == BattleState.ALLY3)
        {
            Debug.Log("Indicator 4 Summoned!");
            newIndicator = Instantiate(indicatorPrefab);
        }
        if (state == BattleState.ALLY4)
        {
            Debug.Log("Indicator 5 Summoned!");
            newIndicator = Instantiate(indicatorPrefab);
        }
        if (state == BattleState.ENEMY1)
        {
            Debug.Log("Indicator 6 Summoned!");
            newIndicator = Instantiate(indicatorPrefab);
        }
        if (state == BattleState.ENEMY2)
        {
            Debug.Log("Indicator 8  Summoned!");
            newIndicator = Instantiate(indicatorPrefab);
        }
        if (state == BattleState.ENEMY3)
        {
            Debug.Log("Indicator 7 Summoned!");
            newIndicator = Instantiate(indicatorPrefab);
        }

        if (newIndicator != null)
        {
            newIndicator.transform.position = GetIndicatorPosition(state); // Set position
            newIndicator.name = $"Indicator {state}"; // Name the object for clarity
            Debug.Log("works");
        }

    }
    
   
    
}
