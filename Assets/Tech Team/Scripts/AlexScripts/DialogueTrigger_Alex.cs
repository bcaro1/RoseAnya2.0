using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // must be used. This allows the script to access the fungus scripts.
using UnityTemplateProjects; // this is for the camera. Has to be included for the scripts to talk.

public class DialogueTrigger_Alex : MonoBehaviour
{
    public Flowchart flowchart; // calls the flowchart.
    public bool hasPlayer; // is the player in a npc's radius?
    public GameObject Player;
    private PlayerMovement PlayerMovementScript;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovementScript = Player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (hasPlayer && Input.GetKeyDown("k"))
        {
            FreezePlayer();
            NormalDialogue();
        }
    }

    void NormalDialogue() // No on going quests
    {
        switch (this.gameObject.tag)
        {
            case "NPC6":
                flowchart.ExecuteBlock("Matron1"); // we execute the named block within the flowchart.
                break;
            case "NPC2":
                flowchart.ExecuteBlock("Blacksmith1"); // we execute the named block within the flowchart.
                break;
            case "NPC3":
                flowchart.ExecuteBlock("Chef1"); // we execute the named block within the flowchart.
                break;
            case "NPC4":
                flowchart.ExecuteBlock("Herbalist1"); // we execute the named block within the flowchart.
                break;
            case "NPC5":
                flowchart.ExecuteBlock("guardIdle"); // we execute the named block within the flowchart.
                break;
            case "NPC11":
                // flowchart.ExecuteBlock("Doctor1"); // we execute the named block within the flowchart.
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
