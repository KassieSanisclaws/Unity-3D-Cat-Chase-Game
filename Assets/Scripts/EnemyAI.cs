using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patrolling, // Enemy is patrolling between points
    Chasing, // Enemy is chasing the player
    Attacking, // Enemy is attacking the player
    Returning // Enemy is returning to the last patrol point    
}

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints; // Array of points to patrol between
    private int currPatrolIndx; // Current index of the patrol point
    public Transform player; // Reference to the player transform
    public float sightRange = 5f; // Range within which the enemy can see the player

    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private EnemyState currState; // Current state of the enemy AI
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currState = EnemyState.Patrolling;
        currPatrolIndx = Random.Range(0, patrolPoints.Length); // NEW: randomize starting patrol point
        GotoNextPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= sightRange && CanSeePlayer())
        {
            currState = EnemyState.Chasing;
        }
        else if (currState == EnemyState.Chasing && distance > sightRange)
        {
            currState = EnemyState.Returning;
        }

        switch (currState)
        {
            case EnemyState.Patrolling:
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPatrolPoint();
                break;
            case EnemyState.Chasing:
                agent.destination = player.position;
                break;
            case EnemyState.Returning:
                currState = EnemyState.Patrolling;
                GotoNextPatrolPoint();
                break;
        }
    }
    void GotoNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.destination = patrolPoints[currPatrolIndx].position;
        currPatrolIndx = (currPatrolIndx + 1) % patrolPoints.Length;
    }

    bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 direction = player.position - transform.position;
        if (Physics.Raycast(transform.position, direction.normalized, out hit, sightRange))
        {
            return hit.collider.CompareTag("Player");
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if (patrolPoints != null && patrolPoints.Length > 1)
        {
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                Vector3 current = patrolPoints[i].position;
                Vector3 next = patrolPoints[(i + 1) % patrolPoints.Length].position;
                Gizmos.DrawLine(current, next);
                Gizmos.DrawSphere(current, 0.3f);
            }
        }
    }
}
