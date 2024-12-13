public class PlagueDoctorHP : HPSystem
{
    void Start()
    {
        HealthPoints = 22;
    }

    void Update()
    {
        if (HealthPoints <= 0)
        {
            UnitDeath();
        }
    }
}