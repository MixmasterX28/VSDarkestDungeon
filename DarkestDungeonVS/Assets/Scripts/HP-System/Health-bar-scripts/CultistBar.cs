public class CultistBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp;
        slider.value = bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp;
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
        slider.value = bs.ExiastingEnemies[2].GetComponent<Acolyte>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
