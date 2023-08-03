using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // The value of the button
    public string buttonValue;
    
    // The keypad controller that this button belongs to
    public KeypadController keypadController;
    
    // Called when the button is pressed
    private void OnTriggerExit(Collider other)
    {
        // Make sure the other object is a hand or controller
        if (other.tag == "Finger" || other.CompareTag("Controller"))
        {
            // Call the PressButton method on the keypad controller, passing in the button value
            keypadController.PressButton(buttonValue);
        }
    }
}
