public class CrusaderHealth : HPSystem
{
    void Start()
    {
        HealthPoints = 33;
    }



    void Update()
    {
        if (HealthPoints <= 0)
        {
            UnitDeath();
        }
    }    
}