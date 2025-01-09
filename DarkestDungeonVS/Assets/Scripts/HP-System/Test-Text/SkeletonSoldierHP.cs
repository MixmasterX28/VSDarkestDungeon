using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SkeletonSoldierHP : TestHPText
{
    // Start is called before the first frame update
    void Start()
    {
        // Ensures health is set up properly.
        if (health == null)
        {
            health = FindObjectOfType<SoldierHealth>();  // Automatically finds the HPSystem component in the scene
        }

        if (textField == null)
        {
            textField = GetComponent<TMP_Text>();  // Makes sure the TMP_Text field is properly assigned
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
        UpdateHealthDisplay();
    }
}
