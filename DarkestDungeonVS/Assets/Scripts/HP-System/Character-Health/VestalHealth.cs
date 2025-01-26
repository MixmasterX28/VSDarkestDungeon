using UnityEngine;
using System.Collections;

public class VestalHealth : HPSystem
{
    private int previousHp;

    public GameObject IdleSpriteObject; // Changed from SpriteRenderer to GameObject
    public SpriteRenderer DefendSpriteRenderer;

    void Start()
    {
        hp = 24;
        previousHp = Mathf.FloorToInt(hp);

        if (DefendSpriteRenderer != null)
        {
            DefendSpriteRenderer.enabled = false;
        }

        if (IdleSpriteObject != null)
        {
            IdleSpriteObject.SetActive(true); // Ensure the idle object is active initially
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
        // Enable the child SpriteRenderer and disable the parent object
        if (DefendSpriteRenderer != null && IdleSpriteObject != null)
        {
            DefendSpriteRenderer.enabled = true;
            IdleSpriteObject.SetActive(false); // Disable the entire idle object

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Revert to the parent object
            DefendSpriteRenderer.enabled = false;
            IdleSpriteObject.SetActive(true); // Re-enable the idle object
        }
    }
}
