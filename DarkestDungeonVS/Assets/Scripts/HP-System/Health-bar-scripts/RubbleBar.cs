public class RubbleBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = 8;
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
        slider.value = bs.ExiastingEnemies[0].GetComponent<RabbleHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
