using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    private FieldOfView fov;

    public Animator playerAnimator;

    private bool playerIsDead;

    [SerializeField] private GameObject deathScreen;

    //para patrulhar
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private void Awake()
    {
        fov = GetComponent<FieldOfView>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!fov.canSeePlayer) Patroling();
        if (fov.canSeePlayer && !playerIsDead) ChasePlayer();
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
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        //when trigger inside animation is triggered, kill the player
        //play player death animation, provavelmente uma animação da câmara a cair no chão
        playerIsDead = true;
        playerAnimator.SetTrigger("IsDead");
        /*player.gameObject.GetComponent<PlayerLook>().enabled = false;
        player.gameObject.GetComponent<PlayerMotor>().enabled = false;
        player.gameObject.GetComponent<CharacterController>().enabled = false;*/
        player.gameObject.GetComponent<InputManager>().enabled = false;
        player.gameObject.GetComponent<Collider>().enabled = false;
        deathScreen.SetActive(true);
        Invoke("ReturnToMm",5f);
    }

    private void ReturnToMm()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
