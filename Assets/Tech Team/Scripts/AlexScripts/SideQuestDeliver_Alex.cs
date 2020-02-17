﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuestDeliver_Alex : MonoBehaviour
{
    #region Public
    public GameObject deliverableObject; // deliverable object 
    public bool holdingObject; // is the player holding the object
    public float height;
    #endregion

    #region Private
    private GameObject player; // player
    #endregion
    void Awake()
    {
        // REFERENCES //
        player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
        deliverableObject = GameObject.FindGameObjectWithTag("Deliverable"); // Grabs deliverable object

        // ASSIGNING VARIABLES //
        holdingObject = false; 
    }
    void Update()
    {
        
    }
    public void GiveObjectToPlayer()
    {
        Vector3 playerPosition;

        // 2 WAYS OF DOING THIS //

        // NPC GIVES PLAYER OBJECT
            // call this function in fungus
            // set holdingObject = true
            // show object above player's head
            // hide object

        // PLAYER PICKS UP OBJECT
            // show object in scene after player accepts quest from npc 
            holdingObject = true; 
            deliverableObject.transform.parent = player.transform; // set deliverable object child of player
            playerPosition = player.transform.position; // grab players current position
            deliverableObject.transform.position = playerPosition; // set deliverable object to players current position 
            deliverableObject.transform.position = new Vector3(playerPosition.x, playerPosition.y + height, playerPosition.z); // raise height
            StartCoroutine(HideObject()); 
    }
    public void GiveObjectToNPC()
    {
        // in fungus - check if holdingObject = true
        // in fungus - run this function
        // set holdingObject = false
        // set this side quest as complete

    }
     IEnumerator HideObject()
    {
        yield return new WaitForSeconds (3.0f);
        deliverableObject.active = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deliverable")
        {
            GiveObjectToPlayer();
        }
    }
}
