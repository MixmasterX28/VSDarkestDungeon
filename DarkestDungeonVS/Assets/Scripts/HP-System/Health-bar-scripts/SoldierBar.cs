public class SoldierBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = 10;
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
        slider.value = bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
