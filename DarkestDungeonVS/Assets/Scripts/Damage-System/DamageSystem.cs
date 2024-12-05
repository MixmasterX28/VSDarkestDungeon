using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private List<HPSystem> characterHP;

    private void Start()
    {
        characterHP = new List<HPSystem>();

        // Find all objects in the scene that have a component implementing HPSystem
        foreach (var character in FindObjectsOfType<MonoBehaviour>())
        {
            if (character is HPSystem hpSystem)
            {
                characterHP.Add(hpSystem);
            }
        }
    }

    public void TriggerDamage()
    {
        foreach (HPSystem v in characterHP)
        {
            v.Damage();
        }
    }

}
