using TMPro;
using UnityEngine;

public class TestHPText : MonoBehaviour
{
    private HPSystem healthText;  // References to the HPSystem component
    private TMP_Text textField;  // References to the TMP_Text component
    public HPSystem HealthText
    {
        get { return healthText; }
        set { healthText = value; }
    }

    public TMP_Text TextField
    {
        get { return textField; }
        set { textField = value; }
    }

    public void HealthCheck() // Makes sure the HP won't go below 0
    {
        if (healthText.HealthPoints <= 0)
        {
            healthText.HealthPoints = 0;
        }
    }
    public void UpdateHealthDisplay()
    {
        // Update the UI text with the current HP value
        textField.text = "HP: " + HealthText.HealthPoints.ToString();
    }
}