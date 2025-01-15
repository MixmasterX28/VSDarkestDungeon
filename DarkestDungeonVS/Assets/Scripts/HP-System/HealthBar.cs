using UnityEngine.UI;
using UnityEngine;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetHealth(int Health)
    {
        slider.value = (float)Health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxvalue = (float)health;

        slider.value = (float)health;

        fill.color = gradient.Evaluat(1f);
    
    }

}
