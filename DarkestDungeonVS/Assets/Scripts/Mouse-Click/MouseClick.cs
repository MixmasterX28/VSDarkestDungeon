using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private DamageSystem damageSystem;
    private enum State { Deactive, Active } // Makes it possible to give an active state or a deactive state
    private State myState = State.Deactive;

    public System.Action OnMouseClickUsed; // Event to notify when the script is used

    private void Start()
    {
        if (damageSystem == null)
        {
            damageSystem = GetComponent<DamageSystem>(); // Is misschien optioneel, maar ik behoud het even tot we zeker weten dat we het niet nodig hebben
        }
    }

    private void Update()
    {
        if (myState == State.Deactive)
        {
            GetComponent<Renderer>().material.color = Color.white; // Deactive state that keeps the object color white
        }
        else if (myState == State.Active)
        {
            GetComponent<Renderer>().material.color = Color.red; // Active state that makes the object red

            if (Input.GetMouseButtonDown(0))
            {
                if (damageSystem != null)
                {
                    damageSystem.Damage();
                    this.enabled = false; // Deactivate the script after use
                    OnMouseClickUsed?.Invoke(); // Notify that the script was used
                }
            }
        }
    }

    private void OnMouseOver()
    {
        myState = State.Active; // Activates the object when the mouse hovers over the object
    }

    private void OnMouseExit()
    {
        myState = State.Deactive; // Deactivates the object when the mouse when the mouse hovers away from the object
    }
}