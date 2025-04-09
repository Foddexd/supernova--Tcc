using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{   
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatisplayer;

    public float health;

    //patrulhar
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //ataque
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //Tipos
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public LayerMask sightBlockers;

    public Transform[] wayPoints;
    private int currentWayPoint = -1;

    private void Awake()
    {
        player = GameObject.Find("Jogador").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatisplayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatisplayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }

    private void Patroling() 
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //alcançou walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //float randomZ = Random.Range(-walkPointRange, walkPointRange);
        //float randomX = Random.Range(-walkPointRange, walkPointRange);

        //currentWayPoint = Random.Range(0, wayPoints.Length);

        currentWayPoint++;
        if (currentWayPoint > wayPoints.Length - 1) currentWayPoint = 0;

        float randomZ = wayPoints[currentWayPoint].position.z;
        float randomX = wayPoints[currentWayPoint].position.x;

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);   

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer() 
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //codigo do ataque aqui
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked= false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, attackRange);
         Gizmos.color = Color.yellow;
         Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
