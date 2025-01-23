public class PlagueDrBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp;
        slider.value = bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        UpdateHealthBar();
        if (slider.value == 0)
        {
            GoAway();
        }
    }

    public void UpdateHealthBar()
    {
        slider.value = bs.ExiastingAllies[3].GetComponent<PlagueDoctorHP>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
