using System;
using TMPro;
using UnityEngine;

public class VestalText : TestHPText
{

    [SerializeField] TMP_Text textField;
    void Start()
    {

        // Ensures health is set up properly.
        if (health == null)
        {
            health = FindObjectOfType<VestalHealth>();  // Automatically finds the HPSystem component in the scene
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