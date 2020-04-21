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
    public GameObject NPCUI;
    private bool playerTalking, checkEndConvo, IntroDialogue_doOnce, EndDialogue_doOnce;
    #endregion

    void Awake()
    {
        // REFERENCES //
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
        NPCUI = GameObject.FindGameObjectWithTag("npcUI"); // Grabs NPC UI
        PlayerMovementScript = Player.GetComponent<PlayerMovement>(); // Grabs movement script attached to Player

        // VARIABLES //
        playerTalking = false;
        checkEndConvo = false;
        IntroDialogue_doOnce = false; 
        EndDialogue_doOnce = false;
    }
    void Start()
    {
        NPCUI.SetActive(false);
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
            IntroDialogue();
            EndDialogue();
            // if (checkEndConvo) { EndConvo(); } // Only want to run this when the player interacts with an NPC. Or else it will throw an error.
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
                flowchart.ExecuteBlock("Fisherman2");
                break;
            case "Doctor":
                StartConvo();   
                flowchart.ExecuteBlock("Doctor");
                break;
            case "Chef":
                StartConvo();   
                flowchart.ExecuteBlock("Chef");
                break;
            case "SpiceMerchant":
                StartConvo();   
                flowchart.ExecuteBlock("Spice Merchant");
                break;
            case "Fisherman3":
                StartConvo();
                flowchart.ExecuteBlock("Fisherman3");
                break;
            case "BookMerchant":
                StartConvo();
                flowchart.ExecuteBlock("Book Merchant");
                break;
            case "Painter":
                StartConvo();
                flowchart.ExecuteBlock("Painter");
                break;
            case "WineSeller":
                StartConvo();
                flowchart.ExecuteBlock("Wine Seller");
                break;
            case "Elderly1":
                StartConvo();
                flowchart.ExecuteBlock("Elderly1");
                break;
            case "Jimothy":
                StartConvo();
                flowchart.ExecuteBlock("Jimothy");
                break;
            case "Jeanie":
                StartConvo();
                flowchart.ExecuteBlock("Jeanie");
                break;
            case "Hero2":
                StartConvo();
                flowchart.ExecuteBlock("Hero2");
                break;
            case "PotionSeller":
                StartConvo();
                flowchart.ExecuteBlock("PotionSeller"); 
                break;
            case "Elderly2":
                StartConvo();
                flowchart.ExecuteBlock("Elderly2");
                break;
            case "Elderly3":
                StartConvo();
                flowchart.ExecuteBlock("Elderly3");
                break;
            case "JMother":
                StartConvo();
                flowchart.ExecuteBlock("JMother");
                break;
            case "JFather":
                StartConvo();
                flowchart.ExecuteBlock("JFather");
                break;
            case "JSis":
                StartConvo();
                flowchart.ExecuteBlock("Jsis");
                break;
            case "CoopMan":
                StartConvo();
                flowchart.ExecuteBlock("CoopMan");
                break;
            case "FruitMerchant1":
                StartConvo();
                flowchart.ExecuteBlock("FruitMerchant1");
                break;
            case "FruitMerchant2":
                StartConvo();
                flowchart.ExecuteBlock("FruitMerchant2"); 
                break;
            case "Portobello":
                StartConvo();
                flowchart.ExecuteBlock("Portobello");
                break;
            case "Student1":
                StartConvo();
                flowchart.ExecuteBlock("Student1");
                break;
            case "Mayor":
                StartConvo();
                flowchart.ExecuteBlock("Mayor");
                break;
            case "Chicken":
                StartConvo();
                flowchart.ExecuteBlock("Chicken");
                break;
            case "Busy1":
                StartConvo();
                flowchart.ExecuteBlock("BusyNpc1");
                break;
            case "Busy2":
                StartConvo();
                flowchart.ExecuteBlock("BusyNpc2");
                break;
            case "Student2":
                StartConvo();
                flowchart.ExecuteBlock("Student2");
                break;
            case "OutsideKid":
                StartConvo();
                flowchart.ExecuteBlock("OutsideKid1");
                break;
            case "OutsideKid2":
                StartConvo();
                flowchart.ExecuteBlock("OutsideKid2");
                break;
            case "OutsideKid3":
                StartConvo();
                flowchart.ExecuteBlock("OutsideKid3");
                break;
            case "HotelKeeper":
                StartConvo();
                flowchart.ExecuteBlock("Innkeeper");
                break;
            case "Student3":
                StartConvo();
                flowchart.ExecuteBlock("Student3"); 
                break;
            case "Student4":
                StartConvo();
                flowchart.ExecuteBlock("Student4"); 
                break;
            case "Mafioso":
                StartConvo();
                flowchart.ExecuteBlock("Mafioso");
                break;
            case "Teacher":
                StartConvo();
                flowchart.ExecuteBlock("Teacher");
                break;
            case "InvisbleBookNote":
                StartConvo();
                flowchart.ExecuteBlock("BookNote1");
                break;
            case "InvisibleBookNote2":
                StartConvo();
                flowchart.ExecuteBlock("BookNote2");
                break;
            case "SelfDialogue":
                StartConvo();
                flowchart.ExecuteBlock("SelfDialogue1");
                break;
            case "SelfDialogue2":
                StartConvo();
                flowchart.ExecuteBlock("SelfDialogue2");
                break;
            case "SelfDialogue3":
                StartConvo();
                flowchart.ExecuteBlock("SelfDialogue3");
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
        // if (flowchart.SelectedBlock.ActiveCommand == null)
        // {
            UnfreezePlayer(); // Unfreeze Player
            anim.SetBool("isTalking", false); // Stop NPC Talking Animation
            flowchart.SetBooleanVariable("playerTalking", false); // Stop Player Talking Animation
            checkEndConvo = false;
        // }   
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

    public void IntroDialogue()
    {
        if ((this.gameObject.tag == "Fisherman1") && (!IntroDialogue_doOnce)) 
        {
            checkEndConvo = true;
            StartConvo();
            flowchart.ExecuteBlock("Intro Dialogue"); 
            IntroDialogue_doOnce = true;
        }
    }
    public void EndDialogue()
    {
        if ((this.gameObject.tag == "Hero") && (!EndDialogue_doOnce))
        {
            checkEndConvo = true;
            StartConvo();
            flowchart.ExecuteBlock("Hero2");
            EndDialogue_doOnce = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is in NPC's radius
        {
            hasPlayer = true;
            NPCUI.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
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
            NPCUI.SetActive(false);
        }
    }
}
