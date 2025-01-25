using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHealth : HPSystem
{
    private int previousHp;

    public SpriteRenderer IdleSpriteRenderer;
    public SpriteRenderer DefendSpriteRenderer;
    void Start()
    {
        hp = 10;
        previousHp = Mathf.FloorToInt(hp);

        if (DefendSpriteRenderer != null)
        {
            DefendSpriteRenderer.color = new Color(DefendSpriteRenderer.color.r, DefendSpriteRenderer.color.g, DefendSpriteRenderer.color.b, 0);
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }

        if (hp < previousHp)
        {
            StartCoroutine(SwitchSpritesTemporarily());
            previousHp = Mathf.FloorToInt(hp);
        }
    }

    private IEnumerator SwitchSpritesTemporarily()
    {
        // Enable the child SpriteRenderer and disable the parent
        if (DefendSpriteRenderer != null && IdleSpriteRenderer != null)
        {
            IdleSpriteRenderer.color = new Color(IdleSpriteRenderer.color.r, IdleSpriteRenderer.color.g, IdleSpriteRenderer.color.b, 0); // Fully transparent
            DefendSpriteRenderer.color = new Color(DefendSpriteRenderer.color.r, DefendSpriteRenderer.color.g, DefendSpriteRenderer.color.b, 1);   // Fully visible

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Revert to the parent sprite
            IdleSpriteRenderer.color = new Color(IdleSpriteRenderer.color.r, IdleSpriteRenderer.color.g, IdleSpriteRenderer.color.b, 1); // Fully transparent
            DefendSpriteRenderer.color = new Color(DefendSpriteRenderer.color.r, DefendSpriteRenderer.color.g, DefendSpriteRenderer.color.b, 0);   // Fully visible
        }

    }
}
