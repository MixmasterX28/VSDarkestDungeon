using UnityEngine;
using System.Collections.Generic;

public class TriggerDamageScript : MonoBehaviour
{
    [SerializeField] private List<MouseClick> mouseClickScripts; // List of MouseClick scripts

    private void Start()
    {
        if (mouseClickScripts != null && mouseClickScripts.Count > 0)
        {
            foreach (var mouseClickScript in mouseClickScripts)
            {
                if (mouseClickScript != null)
                {
                    mouseClickScript.enabled = false; // Ensure the script starts deactivated
                    mouseClickScript.OnMouseClickUsed += ResetMouseClick; // Subscribe to the event
                }
                else
                {
                    Debug.LogError("A MouseClick script reference is missing in the list!");
                }
            }
        }
        else
        {
            Debug.LogError("MouseClick scripts list is empty or not assigned!");
        }
    }

    public void ToggleMouseClick()
    {
        if (mouseClickScripts != null && mouseClickScripts.Count > 0)
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
    }

    public void AddAlly(MouseClick click)
    {
        // add to list
        mouseClickScripts.Add(click);
    }

    private void ResetMouseClick()
    {
        Debug.Log("MouseClick scripts have been reset.");
        foreach (var mouseClickScript in mouseClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.enabled = false; // Deactivate the script
                mouseClickScript.gameObject.GetComponent<Renderer>().material.color = Color.white; // Reset color
            }
        }
    }

    private void OnDestroy()
    {
        if (mouseClickScripts != null)
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
}