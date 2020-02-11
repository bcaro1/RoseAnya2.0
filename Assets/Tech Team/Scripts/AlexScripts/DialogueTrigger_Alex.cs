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
        if (hasPlayer && Input.GetKeyDown("k"))
        { 
            Dialogue();
        }
    }

    void Dialogue() 
    {
        FreezePlayer();
        switch (this.gameObject.tag)
        {
            case "Matron":
                flowchart.ExecuteBlock("Matron1"); // we execute the named block within the flowchart.
                break;
            case "Blacksmith":
                flowchart.ExecuteBlock("Blacksmith1"); // we execute the named block within the flowchart.
                break;
            case "Chef":
                flowchart.ExecuteBlock("Chef1"); // we execute the named block within the flowchart.
                break;
            case "Herbalist":
                flowchart.ExecuteBlock("Herbalist1"); // we execute the named block within the flowchart.
                break;
            case "Doctor":
                flowchart.ExecuteBlock("Doctor1"); // we execute the named block within the flowchart.
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
