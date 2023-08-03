using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puzzel_1; // Puzzle 1 game object
    public GameObject puzzel_2; // Puzzle 2 game object
    public GameObject puzzel_3; // Puzzle 3 game object

    private void Awake()
    {
        int randomNumber = Random.Range(0, 3); // Generate a random number between 0 and 2 (inclusive)

        switch (randomNumber)
        {
            case 0:
                puzzel_1.SetActive(true); // Activate Puzzle 1 game object
                break;
            case 1:
                puzzel_2.SetActive(true); // Activate Puzzle 2 game object
                break;
            case 2:
                puzzel_3.SetActive(true); // Activate Puzzle 3 game object
                break;
        }

        Debug.Log(randomNumber); // Output the randomly generated number to the console for debugging purposes
    }
}
