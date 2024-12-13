public class HighwayManHealth : HPSystem
{
    void Start()
    {
        healthPoints = 23;
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            UnitDeath();
        }
    }
}