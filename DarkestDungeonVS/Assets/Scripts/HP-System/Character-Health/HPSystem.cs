using UnityEngine;

public class HPSystem : MonoBehaviour 
{
    private int damage;
    private float HP;
  
    public float hp
    {
        get { return HP; }
        set { HP = value; }
    }

    public void Die()
    {
            Destroy(gameObject);  // Destroys the object when HP reaches 0
            HP = 0;
    }

    public void Damage()
    {
        damage = Random.Range(1,9);

        HP -= damage;
        Debug.Log(HP);
    }
}