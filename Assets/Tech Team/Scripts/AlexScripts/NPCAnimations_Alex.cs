using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimations_Alex : MonoBehaviour
{
    #region Public
    [Tooltip("Drag and drop NPC's animator here")]
    public Animator animNPC;
    #endregion

    #region Private
    public NavMeshAgent agent;
    private DialogueTrigger_Alex DialogueTriggerScript;
    Vector3 unpausedSpeed;
    #endregion
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        DialogueTriggerScript = GetComponent<DialogueTrigger_Alex>(); //Grabs script attached to NPC
        unpausedSpeed = agent.velocity;

        if (agent != null)
        {
            animNPC.SetBool("isWalking", true);
        }
    }


    void Update()
    {
        NPCTalking();
        SetMovement();
    }

    void SetMovement()
    {   
        if (DialogueTriggerScript.hasPlayer)
        {
            // unpausedSpeed = agent.velocity;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            animNPC.SetBool("isWalking", false);
        }
        else
        {
            agent.isStopped = false;
            animNPC.SetBool("isWalking", true);
        }
    }
    void NPCTalking()
    {
        // If player is in NPCs radius and interacts, change isTalking in animator
        if (DialogueTriggerScript.hasPlayer && Input.GetButtonDown("Interact"))
        {
            animNPC.SetBool("isTalking", true);
        }
        if (!DialogueTriggerScript.hasPlayer)
        {
            animNPC.SetBool("isTalking", false);
        }
    }

}
