public class CrusaderBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp;
        slider.value = bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp;
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
        slider.value = bs.ExiastingAllies[0].GetComponent<CrusaderHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
