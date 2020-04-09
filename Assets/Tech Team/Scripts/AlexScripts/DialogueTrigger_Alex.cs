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
    public PlayerMovement PlayerMovementScript;
    #endregion

    #region Private
    private Animator anim;
    private bool playerTalking, checkEndConvo;
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
        PlayerMovementScript = Player.GetComponent<PlayerMovement>(); // Grabs movement script attached to Player
    }

    private void Update()
    {
        if (hasPlayer && Input.GetButtonDown("Interact"))
        { 
            Dialogue();
            checkEndConvo = true;
        }
        if (hasPlayer)
        {
            if (checkEndConvo) { EndConvo(); } // Only want to run this when the player interacts with an NPC. Or else it will throw an error.
        }
        
    }

    void Dialogue() 
    {
        // FreezePlayer();
        switch (this.gameObject.tag)
        {
            case "Fisherman1":
                StartConvo();
                flowchart.ExecuteBlock("Intro Dialogue"); // we execute the named block within the flowchart.
                break;
            case "Fisherman2":
                StartConvo();            
                flowchart.ExecuteBlock("Fisherman2"); // we execute the named block within the flowchart.
                break;
            case "Doctor":
                StartConvo();   
                flowchart.ExecuteBlock("Doctor"); // we execute the named block within the flowchart.
                break;
            case "Chef":
                StartConvo();   
                flowchart.ExecuteBlock("Chef"); // we execute the named block within the flowchart.
                break;
            case "SpiceMerchant":
                StartConvo();   
                flowchart.ExecuteBlock("Spice Merchant"); // we execute the named block within the flowchart.
                break;
            case "Fisherman3":
                StartConvo();
                flowchart.ExecuteBlock("Fisherman3"); // we execute the named block within the flowchart.
                break;
            case "BookMerchant":
                StartConvo();
                flowchart.ExecuteBlock("Book Merchant"); // we execute the named block within the flowchart.
                break;
            case "Painter":
                StartConvo();
                flowchart.ExecuteBlock("Painter"); // we execute the named block within the flowchart.
                break;
            case "WineSeller":
                StartConvo();
                flowchart.ExecuteBlock("Wine Seller"); // we execute the named block within the flowchart.
                break;
            case "Elderly1":
                StartConvo();
                flowchart.ExecuteBlock("Elderly1"); // we execute the named block within the flowchart.
                break;
            case "Jimothy":
                StartConvo();
                flowchart.ExecuteBlock("Jimothy"); // we execute the named block within the flowchart.
                Talking();
                break;
            case "Jeanie":
                StartConvo();
                flowchart.ExecuteBlock("Jeanie"); // we execute the named block within the flowchart.
                break;
            case "Hero":
                StartConvo();
                flowchart.ExecuteBlock("Hero2"); // we execute the named block within the flowchart.
                break;
            
        }
    }
    public void StartConvo()
    {
        FreezePlayer(); // Freeze Player
        anim.SetBool("isTalking", true); // Run NPC Talking Animation
        flowchart.SetBooleanVariable("playerTalking", true); // Run Player Talking Animation
    }
    public void EndConvo()
    {   
        if (flowchart.SelectedBlock.ActiveCommand == null)
        {
            UnfreezePlayer(); // Unfreeze Player
            anim.SetBool("isTalking", false); // Stop NPC Talking Animation
            flowchart.SetBooleanVariable("playerTalking", false); // Stop Player Talking Animation
            checkEndConvo = false;
        }   
    }
    public void Talking() // Not using
    {
        playerTalking = flowchart.GetBooleanVariable("playerTalking");

        if (playerTalking)
        {
            anim.SetBool("isTalking", true);
        }
        else
        {
            anim.SetBool("isTalking", false);
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
