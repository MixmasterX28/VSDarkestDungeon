using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayBar : HealthBar
{
    private void Start()
    {
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
