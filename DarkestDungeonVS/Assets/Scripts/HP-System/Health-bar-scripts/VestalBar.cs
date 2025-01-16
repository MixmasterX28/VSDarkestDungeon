using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestalBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp;
        slider.value = bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp);

    }

    private void Update()
    {
        Debug.Log(bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
        slider.value = bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
