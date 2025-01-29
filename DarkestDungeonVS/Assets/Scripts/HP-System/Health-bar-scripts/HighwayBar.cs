public class HighwayBar : HealthBar
{
    private void Start()
    {
        slider.maxValue = bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp;
        slider.value = bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        UpdateHealthBar();
        if (slider.value == 0)
        {
            //GoAway();
        }
    }

    public void UpdateHealthBar()
    {
        slider.value = bs.ExiastingAllies[2].GetComponent<HighwayManHealth>().hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
