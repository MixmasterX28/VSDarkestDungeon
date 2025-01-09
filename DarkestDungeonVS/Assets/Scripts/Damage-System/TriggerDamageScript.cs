using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TriggerDamageScript : MonoBehaviour
{
    [SerializeField] private List<MouseClick> mouseClickScripts = new List<MouseClick>(); // Initialize the list
    private BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindAnyObjectByType<BattleSystem>();


        if (mouseClickScripts.Count > 0)
        {
            foreach (var mouseClickScript in mouseClickScripts)
            {
                mouseClickScript.OnMouseClickUsed += ResetMouseClick; // Subscribe to the event
                mouseClickScript.enabled = false; // Ensure the script starts deactivated
            }
        }
        else
        {
            Debug.LogError("MouseClick scripts list is empty or not assigned!");
        }
    }

    public void ToggleMouseClick()
    {
        foreach (var mouseClickScript in mouseClickScripts)
        {
            if (mouseClickScript != null && !mouseClickScript.enabled)
            {
                mouseClickScript.enabled = true; // Activate the MouseClick script
                Debug.Log($"MouseClick script activated on {mouseClickScript.gameObject.name}.");
            }
        }
    }

    public void AddAlly(MouseClick click)
    {
        if (click == null)
        {
            Debug.LogError("Tried to add a null MouseClick reference!");
            return;
        }

        mouseClickScripts.Add(click); // Add to the list
        click.OnMouseClickUsed += ResetMouseClick; // Subscribe to the event
        click.enabled = false; // Ensure the script starts disabled

        Debug.Log($"MouseClick script added for {click.gameObject.name}");
    }


    public void ResetMouseClick()
    {
        Debug.Log("MouseClick scripts have been reset.");
        foreach (var mouseClickScript in mouseClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.white; // Reset color
                mouseClickScript.enabled = false; // Deactivate the script
                battleSystem.BattleStateSwitch();
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var mouseClickScript in mouseClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.OnMouseClickUsed -= ResetMouseClick; // Unsubscribe to prevent memory leaks
            }
        }
    }
}
