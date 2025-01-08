using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbleHealth : HPSystem
{
    void Start()
    {
        hp = 8;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}
