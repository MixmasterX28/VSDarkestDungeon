using UnityEngine;
using System;

public class HPSystem : MonoBehaviour
{
    private float _hp;  // Backing field

    public float hp
    {
        get => _hp;
        set
        {
            _hp = Mathf.Max(0, value);  // Prevent HP from going below 0
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
