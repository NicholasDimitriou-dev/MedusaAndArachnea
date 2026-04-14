using System.Collections;
using UnityEngine;
public class Elevator : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset; 
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 3f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private bool isMoving = false;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + moveOffset;
    }
    public void ActivateElevator()
    {
        if (!isMoving)
        {
            StartCoroutine(ElevatorRoutine());
        }
    }
    private IEnumerator ElevatorRoutine()
    {
        isMoving = true;
        yield return StartCoroutine(MoveTo(targetPosition));
        yield return new WaitForSeconds(waitTime);
        yield return StartCoroutine(MoveTo(startPosition));
        isMoving = false;
    }

    private IEnumerator MoveTo(Vector3 destination)
    {
        while (Vector3.Distance(transform.position, destination) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destination,
                speed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = destination;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            other.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            other.transform.SetParent(null);
        }
    }
}
