using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OverworldMonster_Patrol_Ying : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private float detectionRadius;
    [SerializeField] private float patrolTime;

    public GameObject player;
    public float timeC;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timeC = patrolTime;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= detectionRadius)
        {
            agent.SetDestination(player.transform.position);
            if (distance <= detectionRadius)
            {
                FaceTarget();
            }
        }
        Patrol();
    }

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Patrol()
    {
        timeC += Time.deltaTime;
        if (timeC > patrolTime)
        {
            NewTarget();
            timeC = 0f;
        }
    }

    void NewTarget()
    {
        Vector3 newTarget = RandomTarget(transform.position, detectionRadius, -1);
        agent.SetDestination(newTarget);
    }

    Vector3 RandomTarget(Vector3 curPos, float radius, int layer)
    {
        Vector3 random = Random.insideUnitSphere * radius;
        random += curPos;

        NavMeshHit navHit;
        NavMesh.SamplePosition(random, out navHit, radius, layer);
        return navHit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
