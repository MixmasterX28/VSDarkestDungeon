using System;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    public static event Action HitTest;

    // When this button is clicked this function is called
    public void Test()
    {
        HitTest?.Invoke();  // Invokes the event
    }
}