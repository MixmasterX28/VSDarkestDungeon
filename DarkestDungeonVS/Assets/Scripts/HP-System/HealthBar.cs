using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HighwayManHealth health;  // Reference to the health system
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        // Find health system if it's not assigned
        if (health == null)
        {
            health = FindObjectOfType<HighwayManHealth>();  // Find the health system in the scene
            if (health == null)
            {
                Debug.LogError("No Health System found in the scene!");
                return;
            }
        }

        // Initialize the slider with the health system
        slider.maxValue = health.hp;  // Assuming you have maxHealth in your HighwayManHealth script
        slider.value = health.hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        // Subscribe to health changes
        
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
    }


    // Method to update the health bar value and color
    private void UpdateHealthBar()
    {
        slider.value = health.hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
