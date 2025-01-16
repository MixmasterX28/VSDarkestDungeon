using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingEnemies[0].GetComponent<RabbleHealth>().hp;
        slider.value = bs.ExiastingEnemies[0].GetComponent<RabbleHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(bs.ExiastingEnemies[0].GetComponent<RabbleHealth>().hp);

    }

    private void Update()
    {
        Debug.Log(bs.ExiastingEnemies[0].GetComponent<RabbleHealth>().hp);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
        slider.value = bs.ExiastingEnemies[0].GetComponent<RabbleHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
