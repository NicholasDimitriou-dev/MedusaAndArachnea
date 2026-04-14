using System.Collections;
using UnityEngine;


public class AutoElevator : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset = new Vector3(0, 5, 0);
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 2f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + moveOffset;

        StartCoroutine(ElevatorLoop());
    }
    private IEnumerator ElevatorLoop()
    {
        while (true)
        {
            yield return StartCoroutine(MoveTo(endPosition));
            yield return new WaitForSeconds(waitTime);
            yield return StartCoroutine(MoveTo(startPosition));
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );

            yield return null;
        }

        transform.position = target;
    }
}
