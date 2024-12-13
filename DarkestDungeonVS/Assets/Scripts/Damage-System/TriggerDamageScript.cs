using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TriggerDamageScript : MonoBehaviour
{
    [SerializeField] private List<MouseClick> mouseClickScripts = new List<MouseClick>(); // Initialize the list
    private GameObject[] units;

    private void Start()
    {
        units = GameObject.FindGameObjectsWithTag("Unit");
        foreach (GameObject unit in units)
        {
            MouseClick mouseClick = unit.GetComponent<MouseClick>();
            if (mouseClick != null)
            {
                mouseClickScripts.Add(mouseClick);
            }
            else
            {
                Debug.LogWarning($"GameObject {unit.name} does not have a MouseClick component.");
            }
        }

        if (mouseClickScripts.Count > 0)
        {
            foreach (var mouseClickScript in mouseClickScripts)
            {
                mouseClickScript.enabled = false; // Ensure the script starts deactivated
                mouseClickScript.OnMouseClickUsed += ResetMouseClick; // Subscribe to the event
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
        foreach (var mouseClickScript in mouseClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.OnMouseClickUsed -= ResetMouseClick; // Unsubscribe to prevent memory leaks
            }
        }
    }
}
