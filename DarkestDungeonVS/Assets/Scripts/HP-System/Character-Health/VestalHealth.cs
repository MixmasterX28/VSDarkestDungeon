public class VestalHealth : HPSystem
{
    void Start()
    {
        healthPoints = 24; 
    }


    void Update()
    {
        if (healthPoints <= 0)
        {
            UnitDeath(); // Activates when the healthPoints reaches 0
        }
    }
}