using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageScript : MonoBehaviour
{
    [SerializeField] private DamageSystem damageSystem; // Reference to the DamageSystem script

    public void OnButtonPress()
    {
        if (damageSystem != null)
        {
            damageSystem.TriggerDamage();
            Debug.Log("Button pressed");
        }
        else
        {
            Debug.LogError("DamageSystem reference not set in TriggerDamageScript!");
        }
    }
}
