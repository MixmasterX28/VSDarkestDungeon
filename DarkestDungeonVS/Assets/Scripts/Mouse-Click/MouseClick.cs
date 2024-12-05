using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private DamageSystem damageSystem;
    private enum State { Deactive, Active }
    private State myState = State.Deactive;

    public System.Action OnMouseClickUsed; // Event to notify when the script is used

    private void Start()
    {
        if (damageSystem == null)
        {
            damageSystem = GetComponent<DamageSystem>();
        }
    }

    private void Update()
    {
        if (myState == State.Deactive)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        else if (myState == State.Active)
        {
            GetComponent<Renderer>().material.color = Color.red;

            if (Input.GetMouseButtonDown(0))
            {
                if (damageSystem != null)
                {
                    damageSystem.Damage();
                    this.enabled = false; // Deactivate the script after use
                    OnMouseClickUsed?.Invoke(); // Notify that the script was used
                    Debug.Log("MouseClick script deactivated after use.");
                }
            }
        }
    }

    private void OnMouseOver()
    {
        myState = State.Active;
    }

    private void OnMouseExit()
    {
        myState = State.Deactive;
    }
}