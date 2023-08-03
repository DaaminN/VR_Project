using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class win : MonoBehaviour
{
    private int keys = 0; // Counter for collected keys

    public GameObject wKing; // White king game object
    public GameObject bKing; // Black king game object
    public GameObject wQueen; // White queen game object
    public GameObject bQueen; // Black queen game object

    public TMP_Text timerText; // UI text element for displaying the timer
    public TMP_Text arrowText; // UI text element for displaying arrow directions
    private float secondsCount; // Current seconds count
    private int minuteCount; // Current minute count
    private int hourCount; // Current hour count

    public AudioClip pointUp; // Sound clip for collecting a key
    public AudioClip Winner; // Sound clip for winning

    public GameObject effect; // Particle effect game object

    void Update()
    {
        UpdateTimerUI(); // Update the timer UI
    }

    // Call this on update to update the timer UI
    public void UpdateTimerUI()
    {
        if (keys < 4)
        {
            // Set timer UI
            secondsCount += Time.deltaTime;
            timerText.text = "Your Time " + hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }
            else if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a specific tag and update the game accordingly

        if (other.tag == "wKing")
        {
            wKing.SetActive(true);
            Destroy(other.gameObject);

            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = pointUp;
            GetComponent<AudioSource>().Play();

            keys++;
        }

        if (other.tag == "bKing")
        {
            bKing.SetActive(true);
            Destroy(other.gameObject);

            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = pointUp;
            GetComponent<AudioSource>().Play();

            keys++;
        }

        if (other.tag == "wQueen")
        {
            wQueen.SetActive(true);
            Destroy(other.gameObject);

            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = pointUp;
            GetComponent<AudioSource>().Play();

            keys++;
        }

        if (other.tag == "bQueen")
        {
            bQueen.SetActive(true);
            Destroy(other.gameObject);

            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = pointUp;
            GetComponent<AudioSource>().Play();

            keys++;
        }

        if (keys == 4)
        {
            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = Winner;
            Win(); // Trigger the win state
        }
    }

    private void Win()
    {
        GetComponent<AudioSource>().Play(); // Play the winning sound
        effect.SetActive(true); // Activate the particle effect
        timerText.gameObject.SetActive(true); // Show the timer text element
        arrowText.gameObject.SetActive(true); // Show the arrow text element
    }
}
