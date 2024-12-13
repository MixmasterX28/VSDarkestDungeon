using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private HPSystem health;
    private int damage;

    private void Start()
    {
        health = GetComponent<HPSystem>();
    }

    public void GetDamage()
    {
        damage = Random.Range(1, 9);
        health.healthPoints -= damage; 
    }
}