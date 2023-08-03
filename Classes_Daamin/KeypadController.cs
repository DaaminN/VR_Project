using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    // The correct code that unlocks the door
    public string correctCode;

    // The text displayed on the keypad screen
    public TextMesh displayText;

    // The text entered by the user
    private string enteredCode = "";

    // The door that the keypad unlocks
    public GameObject Key;

    public GameObject table;

    public AudioClip buttonPress;
    public AudioClip codeWrong;
    public AudioClip codeCorrect;

    // Called when a button on the keypad is pressed
    public void PressButton(string buttonValue)
    {
        // Check if the entered code has reached the maximum length (4 characters)
        if (enteredCode.Length <= 3)
        {
            // Add the button value to the entered code
            enteredCode += buttonValue;

            // Update the display text
            displayText.text = enteredCode;

            // Play button press sound
            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = buttonPress;
            GetComponent<AudioSource>().Play();
        }
    }

    public void Confirm()
    {
        // Check if the entered code is correct
        if (enteredCode == correctCode)
        {
            // Display "Turn Around" on the keypad screen
            displayText.text = "Turn Around";

            // Play correct code sound
            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = codeCorrect;
            GetComponent<AudioSource>().Play();

            // Activate the table game object
            table.SetActive(true);

            // Activate the Key game object
            Key.SetActive(true);

            // Call the Destroy method after 20 seconds
            Invoke("Destroy", 20f);
        }
        else
        {
            // Display "Incorrect" on the keypad screen
            displayText.text = "Incorrect";

            // Play wrong code sound
            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = codeWrong;
            GetComponent<AudioSource>().Play();

            // Call the Clear method after 2 seconds
            Invoke("Clear", 2f);
        }
    }

    // Destroy the table game object
    void Destroy()
    {
        Destroy(table);
    }

    // Called when the "Clear" button is pressed
    public void Clear()
    {
        // Clear the entered code
        enteredCode = "";

        // Update the display text
        displayText.text = "";
    }
}
