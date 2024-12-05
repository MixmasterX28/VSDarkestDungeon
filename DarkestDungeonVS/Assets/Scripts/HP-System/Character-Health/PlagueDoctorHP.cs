using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctorHP : HPSystem
{
    void Start()
    {
        hp = 22;
    }


    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}
