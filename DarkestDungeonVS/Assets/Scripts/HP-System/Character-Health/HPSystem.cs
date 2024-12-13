using UnityEngine;

public class HPSystem : MonoBehaviour, IKill 
{
    private float HealthPoints;
  
    public float healthPoints 
    {
        get { return HealthPoints; } 
        set { HealthPoints = value; }
    }

    // Uses UnitDeath from IKill and makes sure that the objects gets destroyed and the value stays 0
    public void UnitDeath() 
    {
            Destroy(gameObject);  
            HealthPoints = 0; 
    }
}