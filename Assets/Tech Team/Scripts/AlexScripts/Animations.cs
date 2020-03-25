using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animations : MonoBehaviour
{
    #region Private
    private GameObject Player;
    private GameObject NPC;
    private Rigidbody PlayerRb;
    private DialogueTrigger_Alex DialogueTriggerScript;
    private bool onGround;
    #endregion

    #region Public
    [Header("References")]
    [Tooltip("Drag and drop Player's animator here")]
    public Animator anim;
    [Tooltip("Drag and drop NPC's animator here")]
    public Animator animNPC;
    #endregion

    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
        NPC = GameObject.FindGameObjectWithTag("Matron"); // Grabs NPC
        PlayerRb = Player.GetComponent<Rigidbody>(); // Grabs Player's Rigidbody
        DialogueTriggerScript = NPC.GetComponent<DialogueTrigger_Alex>(); //Grabs script attached to NPC

        // ASSIGNING VARIABLES //
        anim.SetBool("isGrounded", true); // Start game with Player grounded
    }

    void Update()
    {
        PlayerMoving();
        PlayerTalking();
        PlayerGliding();
        // PlayerAbsorbDischarge();
    }

    void PlayerMoving()
    {
        // If player is moving and on the ground, change Speed in animator
        if((Input.GetButton("Horizontal") || Input.GetButton("Vertical") && onGround))
        {
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }
    void PlayerTalking()
    {
        // If player is in NPCs radius and interacts, change isTalking in animator
        if (DialogueTriggerScript.hasPlayer && Input.GetButtonDown("Interact"))
        {
            anim.SetBool("isTalking", true);
            // animNPC.SetBool("isTalking", true);
        }
        if (!DialogueTriggerScript.hasPlayer)
        {
            anim.SetBool("isTalking", false);
            // animNPC.SetBool("isTalking", false);
        }
    }
    void PlayerGliding()
    {
        // If Player is on the ground, they cannot glide
        if (onGround)
        {
            anim.SetBool("isGliding", false);
        }
        // If Player jumps off the ground, they cannot glide
        if (Input.GetButtonDown("Jump") && onGround)
        {
            anim.SetBool("isGrounded", false);
        }
        // If Player holds jump button and not on ground, they can glide
        if (Input.GetButton("Jump") && !onGround)
        {
            anim.SetBool("isGliding", true);
        }
        // If Player releases jump button and not on ground, they cannot glide
        if (Input.GetButtonUp("Jump") && !onGround)
        {
            anim.SetBool("isGliding", false);
        } 
    }
    void PlayerAbsorbDischarge() //WIP
    {
        if (Input.GetButtonDown("Absorb"))
        {
            anim.SetBool("isAbsorbing", true);
            DialogueTriggerScript.FreezePlayer();
        }
        else if (Input.GetButtonUp("Absorb"))
        {
            anim.SetBool("isAbsorbing", false);
            DialogueTriggerScript.UnfreezePlayer();
        }
        if (Input.GetButtonDown("Interact"))
        {
            anim.SetBool("isDischarging", true);
            DialogueTriggerScript.FreezePlayer();
        }
        else if (Input.GetButtonUp("Interact"))
        {
            anim.SetBool("isDischarging", false);
            DialogueTriggerScript.UnfreezePlayer();
        }



        // if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Absorb") || anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Discharge"))
        // {
        //     DialogueTriggerScript.FreezePlayer();
        // }
        // else 
        // {
        //     DialogueTriggerScript.UnfreezePlayer();
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If Player is touching the ground...
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("isGrounded", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // If Player is touching the ground...
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("isGrounded", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // If Player is not touching the ground...
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
            anim.SetBool("isGrounded", false);
        }
    }
}
