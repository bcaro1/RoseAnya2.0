using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // must be used. This allows the script to access the fungus scripts.
using UnityTemplateProjects; // this is for the camera. Has to be included for the scripts to talk.

public class DialogueTrigger_Alex : MonoBehaviour
{
    private PlayerController_Alex CanMoveReference; // Referencing Khoa/Alex Script

    public Flowchart flowchart; // calls the flowchart.
    public bool taskDone;
    private bool hasPlayer; // is the player in a collider? yes or no
    private bool isTalking; // is the npc talking
    private bool hasTalked; // is the player in a collider? yes or no

    private void Awake()
    {
        hasTalked = false;
        // CanMoveReference = FindObjectOfType<PlayerController_Alex>();
    }

    private void Update()
    {
        if (hasPlayer && Input.GetKeyDown("k"))
        {
            NormalDialogue();
        }
    }

    void NormalDialogue()
    {
        switch (this.gameObject.tag)
        {
            case "NPC1":
                Debug.Log("NPC1");
                flowchart.ExecuteBlock("Quest Dialogue"); // we execute the named block within the flowchart.
                break;
            case "NPC2":
                Debug.Log("NPC2");
                flowchart.ExecuteBlock("Testing1"); // we execute the named block within the flowchart.
                break;
            case "NPC3":
                Debug.Log("NPC3");
                flowchart.ExecuteBlock("FlavorHW"); // we execute the named block within the flowchart.
                break;
            case "NPC4":
                Debug.Log("NPC4");
                flowchart.ExecuteBlock("FlavorC"); // we execute the named block within the flowchart.
                break;
            case "NPC5":
                Debug.Log("NPC5");
                flowchart.ExecuteBlock("FlavorG"); // we execute the named block within the flowchart.
                break;
        }
    }

    public void FreezePlayer()
    {
        Debug.Log("FreezePlayer");
    }
    public void UnfreezePlayer()
    {
        Debug.Log("UnfreezePlayer");
    }

    void OnTriggerEnter(Collider other) // collider stuff
    {
        if (other.CompareTag("Player")) //if the player is colliding with trigger
        {
            hasPlayer = true; // set hasPlayer to true!
        }
    }
    private void OnTriggerExit(Collider other) //when leaving the trigger
    {
        if (other.CompareTag("Player")) // checks for the player tag
        {
            hasPlayer = false; // sets hasPlayer to be false so dialogue won't play.
        }
    }
}
