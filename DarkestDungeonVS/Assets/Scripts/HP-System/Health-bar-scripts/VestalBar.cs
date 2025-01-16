public class VestalBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp;
        slider.value = bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp;
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
        slider.value = bs.ExiastingAllies[1].GetComponent<VestalHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
