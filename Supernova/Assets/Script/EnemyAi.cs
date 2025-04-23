using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGround;
    public LayerMask sightBlockers;

    public float health;

    // Patrulha
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public Transform[] wayPoints;
    private int currentWayPoint = -1;

    // Ataque
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public Transform firePoint;

    // Detecção
    public float fieldOfView = 120f;
    public float viewDistance = 15f;
    public int rayCount = 25;
    public float attackDistance = 5f; // << distância configurável para atacar

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        bool canSeePlayer = CanSeePlayer();
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool inAttackRange = distanceToPlayer <= attackDistance;

        Debug.Log("can see player: " + canSeePlayer + ", in attack range: " + inAttackRange);

        if (!canSeePlayer)
            Patroling();
        else if (canSeePlayer && !inAttackRange)
            ChasePlayer();
        else if (canSeePlayer && inAttackRange)
            AttackPlayer();
    }

    private void Patroling()
    {
        agent.isStopped = false;

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        currentWayPoint++;
        if (currentWayPoint > wayPoints.Length - 1) currentWayPoint = 0;

        Vector3 target = wayPoints[currentWayPoint].position;
        walkPoint = new Vector3(target.x, transform.position.y, target.z);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;

        if (player != null)
            agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.isStopped = true;
        //agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            GameObject proj = Instantiate(projectile, firePoint.position, firePoint.rotation);
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            Vector3 direction = (player.position - firePoint.position).normalized;
            rb.velocity = direction * 20f;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private bool CanSeePlayer()
    {
        if (player == null) return false;

        Vector3 origin = transform.position + Vector3.up * 1.5f;
        Vector3 directionToPlayer = (player.position - origin).normalized;

        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer < fieldOfView / 2f)
        {
            float distanceToPlayer = Vector3.Distance(origin, player.position);

            if (!Physics.Raycast(origin, directionToPlayer, out RaycastHit hit, distanceToPlayer, sightBlockers))
            {
                if (distanceToPlayer <= viewDistance)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        // Range
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);

        // Visual FOV
        Vector3 origin = transform.position + Vector3.up * 1.5f;
        float angleStep = fieldOfView / (rayCount - 1);
        float startAngle = -fieldOfView / 2f;

        for (int i = 0; i < rayCount; i++)
        {
            float angle = startAngle + angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            Vector3 dir = rotation * transform.forward;
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(origin, dir * viewDistance);
        }
    }
}
