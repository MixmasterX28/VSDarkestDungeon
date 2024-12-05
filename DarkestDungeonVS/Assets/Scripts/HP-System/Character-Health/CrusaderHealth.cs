using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusaderHealth : HPSystem
{
    void Start()
    {
        hp = 33;
    }



    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }    
}
