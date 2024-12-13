using TMPro;
using UnityEngine;

public class TestHPText : MonoBehaviour
{
    private HPSystem HealthText;  // References to the HPSystem component
    private TMP_Text TextField;  // References to the TMP_Text component
    public HPSystem healthText
    {
        get { return HealthText; }
        set { HealthText = value; }
    }

    public TMP_Text textField
    {
        get { return TextField; }
        set { TextField = value; }
    }

    public void HealthCheck() // Makes sure the HP won't go below 0
    {
        if (healthText.healthPoints <= 0)
        {
            healthText.healthPoints = 0;
        }
    }
    public void UpdateHealthDisplay()
    {
        // Update the UI text with the current HP value
        textField.text = "HP: " + HealthText.healthPoints.ToString();
    }
}