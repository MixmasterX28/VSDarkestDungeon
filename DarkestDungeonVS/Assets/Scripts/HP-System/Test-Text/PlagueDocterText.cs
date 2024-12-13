using TMPro;

public class PlagueDocterText : TestHPText
{

    // Start is called before the first frame update
    void Start()
    {

        // Ensures health is set up properly.
        if (HealthText == null)
        {
            HealthText = FindObjectOfType<PlagueDoctorHP>();  // Automatically finds the HPSystem component in the scene
        }

        if (TextField == null)
        {
            TextField = GetComponent<TMP_Text>();  // Makes sure the TMP_Text field is properly assigned
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
        UpdateHealthDisplay();
    }
}