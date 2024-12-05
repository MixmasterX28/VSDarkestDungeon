using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private HPSystem health;
    private int damage;

    private void Start()
    {
        health = GetComponent<HPSystem>();
    }

    public void Damage()
    {
        damage = Random.Range(1, 9);
        health.hp -= damage; 
    }
}