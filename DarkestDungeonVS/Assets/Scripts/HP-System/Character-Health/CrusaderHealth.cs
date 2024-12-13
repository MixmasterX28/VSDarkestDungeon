public class CrusaderHealth : HPSystem
{
    void Start()
    {
        healthPoints = 33;
    }



    void Update()
    {
        if (healthPoints <= 0)
        {
            UnitDeath();
        }
    }    
}