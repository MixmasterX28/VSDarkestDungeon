using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private DamageSystem damageSystem;
    private enum State { Deactive, Active } // Makes it possible to give an active state or a deactive state
    private State myState = State.Deactive;

    public System.Action OnMouseClickUsed; // Event to notify when the script is used
    /* private BattleSystem battleSystem; */

    private void Start()
    {
        /* battleSystem = FindAnyObjectByType<BattleSystem>(); */

        if (damageSystem == null)
        {
            damageSystem = GetComponent<DamageSystem>(); // Optional fallback
        }
    }

    private void Update()
    {
       /* SpriteAttackAllies(BattleState.ALLY1, 0, battlleSystem.InstantiatedAllies); */

        if (myState == State.Deactive)
        {
            GetComponent<Renderer>().material.color = Color.white; // Deactive state keeps the object color white
        }
        else if (myState == State.Active)
        {
            GetComponent<Renderer>().material.color = Color.red; // Active state makes the object red

            if (Input.GetMouseButtonDown(0))
            {
                if (damageSystem != null)
                {
                    damageSystem.DamageTarget(gameObject); // Pass the current gameObject as the target
                    this.enabled = false; // Deactivate the script after use
                    OnMouseClickUsed?.Invoke(); // Notify that the script was used
                }
            }
        }
    }

  /* private void SpriteAttackAllies(BattleState currentState, int index, List<GameObject> entities)
    {
        if (index >= 0 && index < entities.Count && entities[index] != null)
        {
            GameObject entity = entities[index];

            // Get all SpriteRenderer components in the entity and its children
            SpriteRenderer[] spriteRenderers = entity.GetComponentsInChildren<SpriteRenderer>();

            if (spriteRenderers.Length > 1) // Ensure there are multiple SpriteRenderers
            {
                SpriteRenderer defaultSprite = spriteRenderers[1]; // Assume first is default
                SpriteRenderer attackSprite = spriteRenderers[2];  // Assume second is attack

                if (battleSystem.state == currentState)
                {
                    // Enable the attack sprite and disable the default sprite
                    defaultSprite.enabled = false;
                    attackSprite.enabled = true;
                }
                else
                {
                    // Revert to default sprite
                    defaultSprite.enabled = true;
                    attackSprite.enabled = false;
                }
            }
        }
    } */

    private void OnMouseOver()
    {
        myState = State.Active; // Activates the object when the mouse hovers over the object
    }

    private void OnMouseExit()
    {
        myState = State.Deactive; // Deactivates the object when the mouse hovers away
    }
}
