using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRadius_Joseph : MonoBehaviour
{
    #region Public
    public bool PatrolWaiting;
    public float TotalWaitTime = 3f;
    public int Radius = 3;
    #endregion

    #region Private
    private NavMeshAgent Agent;
    private bool Travelling;
    private bool Waiting;
    private float WaitTimer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        //If the Player is traveling to a point and has less than 1 unit left
        //Switch the Point to the next one and set the destination
        if (Travelling && Agent.remainingDistance <= 1f)
        {
            Travelling = false;
            if (PatrolWaiting)
            {
                Waiting = true;
                WaitTimer = 0f;
            }
            else
            {
                SetDestination();
            }
        }

        //If the Agent is set to wait, wait until the time is exceeded then 
        //Switch the Point to the next one and set the destination
        if (Waiting)
        {
            WaitTimer += Time.deltaTime;

            if (WaitTimer >= TotalWaitTime)
            {
                Waiting = false;

                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        //Checks to see if there are points to Patrol
        //If so, gets the location of the point and sets it as the destination
        //Then sets travelling to true
        Vector3 Hold = Random.insideUnitSphere * Radius;  
        Vector3 Target = new Vector3((Hold.x + transform.position.x), transform.position.y, (Hold.z + transform.position.z));
        Agent.SetDestination(Target);
        Travelling = true;

    }
}
