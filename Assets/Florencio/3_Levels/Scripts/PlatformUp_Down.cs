using UnityEngine;

public class PlatformUp_Down : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform pointA; // start (idle)
    [SerializeField] private Transform pointB; // end

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 2f;

    private bool isMoving = false;
    private float timer = 0f;
    private Transform currentTarget;

    private void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Points not assigned.");
            enabled = false;
            return;
        }

        transform.position = pointA.position;
        currentTarget = pointB;
    }

    private void Update()
    {
        if (!isMoving)
        {
            // wait 2 seconds
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                isMoving = true;
                timer = 0f;
            }
        }
        else
        {
            // move toward target
            transform.position = Vector3.MoveTowards(
                transform.position,
                currentTarget.position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
            {
                // snap exactly
                transform.position = currentTarget.position;

                isMoving = false;
                timer = 0f;

                // switch target
                currentTarget = (currentTarget == pointA) ? pointB : pointA;
            }
        }
    }
}