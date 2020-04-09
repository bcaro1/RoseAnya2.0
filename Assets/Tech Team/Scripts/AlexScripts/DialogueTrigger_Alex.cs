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
                break;
            case "Jeanie":
                StartConvo();
                flowchart.ExecuteBlock("Jeanie"); // we execute the named block within the flowchart.
                break;
            case "Hero":
                StartConvo();
                flowchart.ExecuteBlock("Hero2"); // we execute the named block within the flowchart.
                break;
            case "PotionSeller":
                StartConvo();
                flowchart.ExecuteBlock("PotionSeller"); // we execute the named block within the flowchart.
                break;
            case "Elderly2":
                StartConvo();
                flowchart.ExecuteBlock("Elderly2"); // we execute the named block within the flowchart.
                break;
            case "Elderly3":
                StartConvo();
                flowchart.ExecuteBlock("Elderly3"); // we execute the named block within the flowchart.
                break;
            case "JMother":
                StartConvo();
                flowchart.ExecuteBlock("JMother"); // we execute the named block within the flowchart.
                break;
            case "JFather":
                StartConvo();
                flowchart.ExecuteBlock("JFather"); // we execute the named block within the flowchart.
                break;
            case "JSis":
                StartConvo();
                flowchart.ExecuteBlock("Jsis"); // we execute the named block within the flowchart.
                break;
            case "CoopMan":
                StartConvo();
                flowchart.ExecuteBlock("CoopMan"); // we execute the named block within the flowchart.
                break;
            case "FruitMerchant1":
                StartConvo();
                flowchart.ExecuteBlock("FruitMerchant1"); // we execute the named block within the flowchart.
                break;
            case "FruitMerchant2":
                StartConvo();
                flowchart.ExecuteBlock("FruitMerchant2"); // we execute the named block within the flowchart.
                break;
            case "Portobello":
                StartConvo();
                flowchart.ExecuteBlock("Portobello"); // we execute the named block within the flowchart.
                break;
            case "Student1":
                StartConvo();
                flowchart.ExecuteBlock("Student1"); // we execute the named block within the flowchart.
                break;
            case "Mayor":
                StartConvo();
                flowchart.ExecuteBlock("Mayor"); // we execute the named block within the flowchart.
                break;
            case "Chicken":
                StartConvo();
                flowchart.ExecuteBlock("Chicken"); // we execute the named block within the flowchart.
                break;
            case "Busy1":
                StartConvo();
                flowchart.ExecuteBlock("BusyNpc1"); // we execute the named block within the flowchart.
                break;
            case "Busy2":
                StartConvo();
                flowchart.ExecuteBlock("BusyNpc2"); // we execute the named block within the flowchart.
                break;
            case "Student2":
                StartConvo();
                flowchart.ExecuteBlock("Student2"); // we execute the named block within the flowchart.
                break;
            case "OutsideKid":
                StartConvo();
                flowchart.ExecuteBlock("OutsideKid1"); // we execute the named block within the flowchart.
                break;
            case "OutsideKid2":
                StartConvo();
                flowchart.ExecuteBlock("OutsideKid2"); // we execute the named block within the flowchart.
                break;
            case "OutsideKid3":
                StartConvo();
                flowchart.ExecuteBlock("OutsideKid3"); // we execute the named block within the flowchart.
                break;
            case "HotelKeeper":
                StartConvo();
                flowchart.ExecuteBlock("Innkeeper"); // we execute the named block within the flowchart.
                break;
            case "Student3":
                StartConvo();
                flowchart.ExecuteBlock("Student3"); // we execute the named block within the flowchart.
                break;
            case "Student4":
                StartConvo();
                flowchart.ExecuteBlock("Student4"); // we execute the named block within the flowchart.
                break;
            case "Mafioso":
                StartConvo();
                flowchart.ExecuteBlock("Mafioso"); // we execute the named block within the flowchart.
                break;
            case "Teacher":
                StartConvo();
                flowchart.ExecuteBlock("Teacher"); // we execute the named block within the flowchart.
                break;
            case "InvisibleBookNote":
                StartConvo();
                flowchart.ExecuteBlock("BookNote1"); // we execute the named block within the flowchart.
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
