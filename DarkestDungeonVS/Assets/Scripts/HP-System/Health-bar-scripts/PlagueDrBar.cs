using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDrBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp;
        slider.value = bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp);

    }

    private void Update()
    {
        Debug.Log(bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp);
        UpdateHealthBar();

    }

    public void UpdateHealthBar()
    {
        Debug.Log($"HealthBar initialized. Max HP: {slider.maxValue}, Current HP: {slider.value}");
        slider.value = bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
