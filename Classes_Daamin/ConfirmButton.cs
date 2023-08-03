using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public KeypadController keypadController;

    // Called when the button is pressed
    private void OnTriggerEnter(Collider other)
    {
        // Make sure the other object is a hand or controller
        if (other.CompareTag("Finger") || other.CompareTag("Controller"))
        {
            // Call the PressButton method on the keypad controller, passing in the button value
            keypadController.Confirm();
        }
    
    }
}
