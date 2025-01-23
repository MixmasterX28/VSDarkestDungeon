using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private int damage;

    public void DamageTarget(GameObject target)
    {
        if (target == null) return;

        HPSystem hpSystem = target.GetComponent<HPSystem>();
        if (hpSystem != null)
        {
            damage = Random.Range(7, 10);  // Apply random damage
            hpSystem.hp -= damage;  // Deduct health
            Debug.Log($"{target.name} took {damage} damage. Remaining HP: {hpSystem.hp}");
        }
    }
}
