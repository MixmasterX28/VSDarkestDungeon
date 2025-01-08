using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHealth : HPSystem
{
    void Start()
    {
        hp = 10;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}
