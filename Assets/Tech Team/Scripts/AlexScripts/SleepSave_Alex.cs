using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepSave_Alex : MonoBehaviour
{

    [Tooltip("Script will find Player")]
    public GameObject Player;
    public GameObject textUI;
    public bool inRadius;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
    }

    void Update()
    {
        if (inRadius && Input.GetKeyDown(KeyCode.S)) // hardcoded, will change -@AH
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is in radius
        {
            textUI.SetActive(true);
            inRadius = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is out of radius
        {
            textUI.SetActive(false);
            inRadius = false;
        }
    }
}
