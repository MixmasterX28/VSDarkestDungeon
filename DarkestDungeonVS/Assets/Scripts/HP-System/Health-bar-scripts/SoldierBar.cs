using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp;
        slider.value = bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp);

    }

    private void Update()
    {
        Debug.Log(bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
        slider.value = bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
