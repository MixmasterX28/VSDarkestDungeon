using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private DamageSystem damageSystem;
    private enum State { deactive, active } // Makes it possible to give an active state or a deactive state
    private State myState = State.deactive; // myState starts deactive

    public System.Action OnMouseClickUsed; // Event to notify when the script is used
 
    private void Start()
    {
        if (damageSystem == null)
        {
            damageSystem = GetComponent<DamageSystem>(); // Makes sure DamageSystem will be used 
        }
    }

    private void Update()
    {
        if (myState == State.deactive)
        {
            GetComponent<Renderer>().material.color = Color.white; // Deactive state that keeps the object color white
        }
        else if (myState == State.active)
        {
            GetComponent<Renderer>().material.color = Color.red; // Active state that makes the object red

            if (Input.GetMouseButtonDown(0))
            {
                if (damageSystem != null)
                {
                    damageSystem.GetDamage();
                    this.enabled = false; // Deactivate the script after use
                    OnMouseClickUsed?.Invoke(); // Notify that the script was used
                }
            }
        }
    }

    // Activates the object when the mouse hovers over the object
    private void OnMouseOver()
    {
        myState = State.active; 
    }

    // Deactivates the object when the mouse when the mouse hovers away from the object
    private void OnMouseExit()
    {
        myState = State.deactive; 
    }
}