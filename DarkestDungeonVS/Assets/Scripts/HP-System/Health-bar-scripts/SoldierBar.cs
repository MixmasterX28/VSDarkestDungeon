public class SoldierBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp;
        slider.value = bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp;
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
        slider.value = bs.ExiastingEnemies[1].GetComponent<SoldierHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
