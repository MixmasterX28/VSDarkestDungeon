using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private DamageSystem damageSystem; // Reference to the DamageSystem script

    private enum State { Deactive, Active }
    private State myState = State.Deactive;

    private void Start()
    {
            damageSystem = GetComponent<DamageSystem>(); // Try to find the DamageSystem component on the same GameObject
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
                damageSystem.Damage();
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
