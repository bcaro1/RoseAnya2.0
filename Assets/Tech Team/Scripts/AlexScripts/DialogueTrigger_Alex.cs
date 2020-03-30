using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // must be used. This allows the script to access the fungus scripts.
using UnityTemplateProjects; // this is for the camera. Has to be included for the scripts to talk.

public class DialogueTrigger_Alex : MonoBehaviour
{
    #region Public
    [Header("References")]
    [Tooltip("Drag and drop Flowchart here")]
    public Flowchart flowchart; // calls the flowchart.
    [Tooltip("Script will find Player")]
    public GameObject Player;
    [Header("Variables")]
    public bool hasPlayer; // is the player in a npc's radius?
    #endregion

    #region Private
    public PlayerMovement PlayerMovementScript;
    #endregion

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
        PlayerMovementScript = Player.GetComponent<PlayerMovement>(); // Grabs movement script attached to Player
    }

    private void Update()
    {
        if (hasPlayer && Input.GetButtonDown("Interact"))
        { 
            Dialogue();
        }
    }

    void Dialogue() 
    {
        FreezePlayer();
        switch (this.gameObject.tag)
        {
            case "Fisherman1":
                flowchart.ExecuteBlock("Intro Dialogue"); // we execute the named block within the flowchart.
                break;
            case "Fisherman2":
                flowchart.ExecuteBlock("Fisherman2"); // we execute the named block within the flowchart.
                break;
            case "Doctor":
                flowchart.ExecuteBlock("Doctor"); // we execute the named block within the flowchart.
                break;
            case "Chef":
                flowchart.ExecuteBlock("Chef"); // we execute the named block within the flowchart.
                break;
            case "SpiceMerchant":
                flowchart.ExecuteBlock("Spice Merchant"); // we execute the named block within the flowchart.
                break;
            case "Fisherman3":
                flowchart.ExecuteBlock("Fisherman3"); // we execute the named block within the flowchart.
                break;
            case "BookMerchant":
                flowchart.ExecuteBlock("Book Merchant"); // we execute the named block within the flowchart.
                break;
            case "Painter":
                flowchart.ExecuteBlock("Painter"); // we execute the named block within the flowchart.
                break;
            case "WineSeller":
                flowchart.ExecuteBlock("Wine Seller"); // we execute the named block within the flowchart.
                break;
            case "Jimothy":
                flowchart.ExecuteBlock("Jimothy"); // we execute the named block within the flowchart.
                break;
            case "Jeanie":
                flowchart.ExecuteBlock("Jeanie"); // we execute the named block within the flowchart.
                break;
            case "Hero":
                flowchart.ExecuteBlock("Hero2"); // we execute the named block within the flowchart.
                break;
            
        }
    }

    public void FreezePlayer()
    {
        PlayerMovementScript.canMove = false;
    }
    public void UnfreezePlayer()
    {
        PlayerMovementScript.canMove = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is in NPC's radius
        {
            hasPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is out of NPC's radius
        {
            hasPlayer = false;
        }
    }
}
