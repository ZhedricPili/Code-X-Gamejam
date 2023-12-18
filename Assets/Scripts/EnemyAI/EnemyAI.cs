using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    Collider wallcollider;

    //Line of Sight
    public float radius;
    [Range(0, 360)]
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        wallcollider = GetComponent<Collider>();
        player = GameObject.Find("FInalPlayer").transform;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FOVRoutine());
    }

    private void Update()
    {

        //Check for sight and attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange && canSeePlayer == false)
        {
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        }

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
            Invoke(nameof(WallBump), 5f);
        }

        if (!playerInAttackRange && canSeePlayer)
        {
            ChasePlayer();
        }
        else if (playerInAttackRange && canSeePlayer)
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            animator.SetBool("isWalking", true);
            agent.SetDestination(walkPoint);
        }



        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            animator.SetBool("isWalking", false);
            Invoke(nameof(WallBump), 5f);
        }


    }

    private void WallBump()
    {
        animator.SetBool("isWalking", false);
        walkPointSet = false;
        CancelInvoke();
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here preferably animation
            Debug.Log("Ikaw ay na lose");

            ///End of attack code

            alreadyAttacked = true;
            InGameUI.isPlayerDead = alreadyAttacked;
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
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
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

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }

                else

                {
                    canSeePlayer = false;
                }

            }
            else
            {
                canSeePlayer = false;
            }

        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Hit");
            WallBump();
        }
    }

}
