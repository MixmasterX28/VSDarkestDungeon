using UnityEngine;
using System.Collections.Generic;

public class TriggerDamageScript : MonoBehaviour
{
    [SerializeField] private List<MouseClick> playerClickScripts = new List<MouseClick>();
    [SerializeField] private List<MouseClick> enemyClickScripts = new List<MouseClick>();
    private BattleSystem battleSystem;
    private bool damageModeActive = false; // Track if damage mode is active

    private void Start()
    {
        battleSystem = FindAnyObjectByType<BattleSystem>();

        // Disable all MouseClick scripts at the start
        DisableAllMouseClicks();
    }

    public void AddAlly(MouseClick click)
    {
        if (click == null) return;

        playerClickScripts.Add(click);
        click.OnMouseClickUsed += ResetMouseClick;
        click.enabled = false; // Ensure it starts disabled
    }

    public void AddEnemy(MouseClick click)
    {
        if (click == null) return;

        enemyClickScripts.Add(click);
        click.OnMouseClickUsed += ResetMouseClick;
        click.enabled = false; // Ensure it starts disabled
    }

    public void EnableDamageMode()
    {
        // Only allow enabling damage mode during a player's turn
        if (battleSystem == null || !battleSystem.state.ToString().StartsWith("ALLY")) return;

        damageModeActive = true;

        // Enable only enemy MouseClick scripts
        foreach (var mouseClickScript in enemyClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.enabled = true;
                Debug.Log($"{mouseClickScript.gameObject.name} is now clickable.");
            }
        }
    }

    public void ResetMouseClick()
    {
        // Disable all MouseClick scripts and deactivate damage mode
        DisableAllMouseClicks();
        damageModeActive = false;

        // Notify the BattleSystem to switch to the next turn
        if (battleSystem != null)
        {
            battleSystem.BattleStateSwitch();
        }
    }

    private void DisableAllMouseClicks()
    {
        foreach (var mouseClickScript in playerClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.enabled = false;
                mouseClickScript.gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.white; // Reset color
            }
        }

        foreach (var mouseClickScript in enemyClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.enabled = false;
                mouseClickScript.gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.white; // Reset color
            }
        }
    }

    public void SwitchTurn()
    {
        // Directly switch the turn without enabling MouseClick scripts
        if (battleSystem != null)
        {
            battleSystem.BattleStateSwitch();
        }

        // Ensure all MouseClick scripts are disabled after turn switching
        DisableAllMouseClicks();
        damageModeActive = false;
    }

    private void OnDestroy()
    {
        foreach (var mouseClickScript in playerClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.OnMouseClickUsed -= ResetMouseClick;
            }
        }

        foreach (var mouseClickScript in enemyClickScripts)
        {
            if (mouseClickScript != null)
            {
                mouseClickScript.OnMouseClickUsed -= ResetMouseClick;
            }
        }
    }
}
