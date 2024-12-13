public class HighwayManHealth : HPSystem
{
    void Start()
    {
        HealthPoints = 23;
    }

    void Update()
    {
        if (HealthPoints <= 0)
        {
            UnitDeath();
        }
    }
}