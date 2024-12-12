public class HighwayManHealth : HPSystem
{
    void Start()
    {
        hp = 23;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }
}