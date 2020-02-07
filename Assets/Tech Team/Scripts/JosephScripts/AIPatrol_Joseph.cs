using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol_Joseph : MonoBehaviour
{
    #region Public
    public bool PatrolWaiting;
    public float TotalWaitTime = 3f;
    public List<Waypoint_Joseph> PatrolPoints;
    #endregion

    #region Private
    private NavMeshAgent Agent;
    private int CurrentPatrolIndex;
    private bool Travelling;
    private bool Waiting;
    private float WaitTimer;
    #endregion 

    void Start()
    {
        //Gets the NavMeshAgent and Checks if we have enough points to patrol, if so start patrol
        Agent = GetComponent<NavMeshAgent>();

        if(Agent != null)
        {
            if(PatrolPoints != null && PatrolPoints.Count >= 2)
            {
                CurrentPatrolIndex = 0;
                SetDestination();
            }
        }
    }


    void Update()
    {
        //If the Player is traveling to a point and has less than 1 unit left
        //Switch the Point to the next one and set the destination
        if(Travelling && Agent.remainingDistance <= 1f)
        {
            Travelling = false;
            if(PatrolWaiting)
            {
                Waiting = true;
                WaitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        //If the Agent is set to wait, wait until the time is exceeded then 
        //Switch the Point to the next one and set the destination
        if(Waiting)
        {
            WaitTimer += Time.deltaTime;

            if(WaitTimer >= TotalWaitTime)
            {
                Waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        //Checks to see if there are points to Patrol
        //If so, gets the location of the point and sets it as the destination
        //Then sets travelling to true
        if(PatrolPoints != null)
        {
            Vector3 Target = PatrolPoints[CurrentPatrolIndex].transform.position;
            Agent.SetDestination(Target);
            Travelling = true;
        }
    }

    private void ChangePatrolPoint()
    {
        //Increments CurrentPatrolIndex and checks if it is above the maximum, if so it resets to 0
        CurrentPatrolIndex = (CurrentPatrolIndex + 1) % PatrolPoints.Count;
    }
}
