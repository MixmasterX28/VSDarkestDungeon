public class PlagueDoctorHP : HPSystem
{
    void Start()
    {
        healthPoints = 22;
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            UnitDeath();
        }
    }
}