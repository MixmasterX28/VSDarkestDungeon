using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public float HP;  // Variable that stores HP

    public float hp
    {
        get { return HP; }
        set { HP = Mathf.Max(0, value); }  // Prevent HP from going below 0
    }

    public void Die()
    {
        Destroy(gameObject);  // Destroy the object when HP is 0
    }
}
