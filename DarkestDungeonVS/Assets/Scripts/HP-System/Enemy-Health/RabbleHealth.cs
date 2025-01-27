using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbleHealth : HPSystem
{
    private int previousHp;

    public SpriteRenderer IdleSpriteRenderer;
    public SpriteRenderer DefendSpriteRenderer;
    void Start()
    {
        Debug.Log("IdleSpriteRenderer assigned: " + (IdleSpriteRenderer != null));
        Debug.Log("DefendSpriteRenderer assigned: " + (DefendSpriteRenderer != null));

        hp = 15;
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
        Debug.Log("SwitchSpritesTemporarily started.");
        // Enable the child SpriteRenderer and disable the parent
        if (DefendSpriteRenderer != null && IdleSpriteRenderer != null)
        {
            Debug.Log("Switching sprites...");
            IdleSpriteRenderer.color = new Color(IdleSpriteRenderer.color.r, IdleSpriteRenderer.color.g, IdleSpriteRenderer.color.b, 0); // Fully transparent
            DefendSpriteRenderer.color = new Color(DefendSpriteRenderer.color.r, DefendSpriteRenderer.color.g, DefendSpriteRenderer.color.b, 1);   // Fully visible

            Debug.Log($"DefendSpriteRenderer enabled: {DefendSpriteRenderer.enabled}, IdleSpriteRenderer enabled: {IdleSpriteRenderer.enabled}");
            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Revert to the parent sprite
            IdleSpriteRenderer.color = new Color(IdleSpriteRenderer.color.r, IdleSpriteRenderer.color.g, IdleSpriteRenderer.color.b, 1); // Fully transparent
            DefendSpriteRenderer.color = new Color(DefendSpriteRenderer.color.r, DefendSpriteRenderer.color.g, DefendSpriteRenderer.color.b, 0);   // Fully visible
            Debug.Log("Reverted sprites.");
            Debug.Log($"DefendSpriteRenderer enabled: {DefendSpriteRenderer.enabled}, IdleSpriteRenderer enabled: {IdleSpriteRenderer.enabled}");
        }
        else
        {
            Debug.LogError("SpriteRenderer references are null!");
        }

    }
}
