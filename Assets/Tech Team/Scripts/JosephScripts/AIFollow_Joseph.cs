using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow_Joseph : MonoBehaviour
{
    #region Private
    private GameObject Player;
    private Transform TransformToFollow;
    private NavMeshAgent Agent;
    #endregion


    void Start()
    {
        //Gets the Player Object and the NavMeshAgent
        Player = GameObject.FindGameObjectWithTag("Player");
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the Player's Location and Sets it as the Destination
        TransformToFollow = Player.transform;
        Agent.SetDestination(TransformToFollow.position);
    }
}
