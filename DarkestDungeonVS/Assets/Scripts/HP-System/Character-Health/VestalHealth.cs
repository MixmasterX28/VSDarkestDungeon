public class VestalHealth : HPSystem
{
    void Start()
    {
        hp = 24;
    }


    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}