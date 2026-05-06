using UnityEngine;

public class EnemyMovement_NoNavMesh2 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float waitTime = 3f;

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [SerializeField] private Transform arachneaSpawn;
    [SerializeField] private Transform medusaSpawn;

    [SerializeField] private Animator animator;


    private Transform currentTarget;
    private float movementTimer;
    private bool isMoving;
    private bool movingLeft;


    private AudioSource audioSource;

    private void Awake()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("PointA or PointB is not assigned.");
            enabled = false;
            return;
        }

        transform.position = pointA.position;
        currentTarget = pointB;
        isMoving = false;
        movingLeft = false;

        audioSource = GetComponent<AudioSource>();

        UpdateAnimator();
    }

    private void Update()
    {
        if (!isMoving)
        {
            movementTimer += Time.deltaTime;

            if (movementTimer >= waitTime)
            {
                isMoving = true;

                movingLeft = currentTarget == pointA;

                UpdateAnimator();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentTarget.position) <= 0.01f)
            {
                transform.position = currentTarget.position;

                isMoving = false;
                movementTimer = 0f;

                currentTarget = (currentTarget == pointA) ? pointB : pointA;

                movingLeft = currentTarget == pointA;

                UpdateAnimator();
            }
        }
    }

    private void UpdateAnimator()
    {
        if (animator == null)
        {
            return;
        }

        animator.SetBool("IsWalking", isMoving);
        animator.SetBool("MovingLeft", movingLeft);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arachnea"))
        {
            TeleportCharacter(other, arachneaSpawn);
        }
        else if (other.gameObject.CompareTag("Medusa"))
        {
            TeleportCharacter(other, medusaSpawn);
        }
    }

    private void TeleportCharacter(Collider other, Transform spawnPoint)
    {
        if (spawnPoint == null)
        {
            return;
        }

        CharacterController cc = other.gameObject.GetComponent<CharacterController>();

        if (cc != null)
            cc.enabled = false;

        if (audioSource != null)
            audioSource.Play();

        other.transform.position = spawnPoint.position;

        if (cc != null)
            cc.enabled = true;
    }

    public void TurnToStone(Transform stonePrefab)
    {
        if (stonePrefab == null)
        {
            return;
        }

        Transform obj = Instantiate(stonePrefab);
        obj.position = transform.position;
        Destroy(gameObject);
    }
}