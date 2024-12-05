using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayManHealth : HPSystem
{
    void Start()
    {
        hp = 23;
    }



    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}
