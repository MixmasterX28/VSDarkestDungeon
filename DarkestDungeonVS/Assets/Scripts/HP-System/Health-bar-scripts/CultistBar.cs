using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp;
        slider.value = bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp);

    }

    private void Update()
    {
        Debug.Log(bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
        slider.value = bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
