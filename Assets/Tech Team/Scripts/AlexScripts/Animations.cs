using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animations : MonoBehaviour
{
    GameObject Player;
    GameObject NPC;
    private Rigidbody PlayerRb;
    public Animator anim;
    private DialogueTrigger_Alex DialogueTriggerScript;
    
    bool onGround;
    bool playerMoving;

    
    Scene currentScene;
    string sceneName;

    // Start is called before the first frame update
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        Player = GameObject.FindGameObjectWithTag("Player");
        NPC = GameObject.FindGameObjectWithTag("NPC6");
        PlayerRb = Player.GetComponent<Rigidbody>();
        anim.SetBool("isGrounded", true);

        DialogueTriggerScript = NPC.GetComponent<DialogueTrigger_Alex>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        PlayerTalking();

        if (onGround)
        {
            anim.SetBool("isGliding", false);
        }
        if (Input.GetButtonDown("Jump") && onGround)
        {
            anim.SetBool("isGrounded", false);
        }
        if (Input.GetButton("Jump") && !onGround)
        {
            anim.SetBool("isGliding", true);
        }
        if (Input.GetButtonUp("Jump") && !onGround)
        {
            anim.SetBool("isGliding", false);
        } 
    }

    void PlayerMoving()
    {
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
        if (DialogueTriggerScript.hasPlayer && Input.GetKeyDown("k"))
        {
            anim.SetBool("isTalking", true);
        }
        if (!DialogueTriggerScript.hasPlayer)
        {
            anim.SetBool("isTalking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("isGrounded", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("isGrounded", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
            anim.SetBool("isGrounded", false);
        }
    }
}
