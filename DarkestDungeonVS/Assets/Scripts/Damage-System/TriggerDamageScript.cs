using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageScript : MonoBehaviour
{
    [SerializeField] private MouseClick mouseClickScript;

    private bool isActivated = false;

    public void ToggleMouseClick()
    {
        if (mouseClickScript != null)
        {
            if (!isActivated)
            {
                mouseClickScript.enabled = true; // Activate the MouseClick script
                isActivated = true;
                Debug.Log("MouseClick script activated.");
            }
            else
            {
                mouseClickScript.enabled = false; // Deactivate the MouseClick script
                isActivated = false;
                Debug.Log("MouseClick script deactivated.");
            }
        }
        else
        {
            Debug.LogError("MouseClick script reference is missing.");
        }
    }
}
