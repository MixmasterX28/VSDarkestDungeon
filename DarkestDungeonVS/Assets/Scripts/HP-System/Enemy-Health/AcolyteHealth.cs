using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acolyte : HPSystem
{
    void Start()
    {
        hp = 13;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}
