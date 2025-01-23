using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acolyte : HPSystem
{
    private int previousHp;

    public SpriteRenderer IdleSpriteRenderer;
    public SpriteRenderer DefendSpriteRenderer;

    void Start()
    {
        hp = 13;
        previousHp = Mathf.FloorToInt(hp);

        if (DefendSpriteRenderer != null)
        {
            DefendSpriteRenderer.enabled = false;
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
            DefendSpriteRenderer.enabled = true;
            IdleSpriteRenderer.enabled = false;

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Revert to the parent sprite
            DefendSpriteRenderer.enabled = false;
            IdleSpriteRenderer.enabled = true;
        }

    }
}
