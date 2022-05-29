using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    private FieldOfView fov;

    public Animator playerAnimator;

    private bool playerIsDead;

    //para patrulhar
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private void Awake()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        fov = GetComponent<FieldOfView>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!fov.canSeePlayer) Patroling();
        if (fov.canSeePlayer) ChasePlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //se chegar ao walkpoint 
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    //calcula o proximo ponto em que o inimigo vai de maneira aleatoria dentro do walkpointrange
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    //acho que da para perceber pelo nome
    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //play animation
            killPlayer();
        }
    }

    private void killPlayer()
    {
        //when trigger inside animation is triggered, kill the player
        //play player death animation, provavelmente uma animação da câmara a cair no chão
        playerAnimator.Play("Death");
        playerIsDead = true;
    }
}
