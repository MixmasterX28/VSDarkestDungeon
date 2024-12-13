using UnityEngine;

public class HPSystem : MonoBehaviour, IKill 
{
    private float healthPoints;
  
    public float HealthPoints 
    {
        get { return healthPoints; } 
        set { healthPoints = value; }
    }

    // Uses UnitDeath from IKill and makes sure that the objects gets destroyed and the value stays 0
    public void UnitDeath() 
    {
            Destroy(gameObject);  
            healthPoints = 0; 
    }
}