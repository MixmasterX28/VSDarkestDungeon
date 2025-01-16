using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtons : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // The code to restart the scene
    }

    public void Quit()
    {
        Application.Quit(); // The code to quit the game
        Debug.Log("Quit");
    }
}
