using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestalHealth : HPSystem
{
    void Start()
    {
        hp = 24;
    }




    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}
