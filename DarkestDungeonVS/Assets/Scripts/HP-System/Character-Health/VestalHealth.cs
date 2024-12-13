public class VestalHealth : HPSystem
{
    void Start()
    {
        HealthPoints = 24; 
    }


    void Update()
    {
        if (HealthPoints <= 0)
        {
            UnitDeath(); // Activates when the healthPoints reaches 0
        }
    }
}