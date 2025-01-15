using TMPro;
using UnityEngine;

public class TestHPText : MonoBehaviour
{
    private HPSystem Health;  // References to the HPSystem component
    private TMP_Text TextField;  // References to the TMP_Text component
    private BattleSystem BattleSystem;
    public HPSystem health
    {
        get { return Health; }
        set { Health = value; }
    }

    public TMP_Text textField
    {
        get { return TextField; }
        set { TextField = value; }
    }

    public BattleSystem battleSystem
    {
        get { return BattleSystem; }
        set { BattleSystem = value; }
    }

    public void HealthCheck() // Makes sure the HP won't go below 0
    {
        if (health.hp <= 0)
        {
            health.hp = 0;
        }
    }
    public void UpdateHealthDisplay()
    {
        // Update the UI text with the current HP value
        textField.text = "HP: " + health.hp.ToString();
    }

}