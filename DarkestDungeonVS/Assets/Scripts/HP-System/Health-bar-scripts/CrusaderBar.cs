using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusaderBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp;
        slider.value = bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp);

    }

    private void Update()
    {
        Debug.Log(bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
        slider.value = bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
