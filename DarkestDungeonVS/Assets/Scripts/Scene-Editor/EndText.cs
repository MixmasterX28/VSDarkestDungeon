using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EndText : TestHPText
{
    // Start is called before the first frame update
    void Start()
    {
        if (textField == null)
        {
            textField = GetComponent<TMP_Text>();  // Makes sure the TMP_Text field is properly assigned
        }
        
        textField.text = "";

    }

}
