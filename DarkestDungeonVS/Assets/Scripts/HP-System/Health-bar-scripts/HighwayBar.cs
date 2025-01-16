public class HighwayBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = 23;
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
        slider.value = bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
