using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HighwayManHealth health;  // Reference to the health system
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public BattleSystem bs;

    private void Start()
    {
        if (health == null)
        {
            Debug.LogError("No Health System assigned!");
            return;
        }

        slider.maxValue = bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp;
        slider.value = bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp);

    }

    private void Update()
    {
        Debug.Log(bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
        slider.value = bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
