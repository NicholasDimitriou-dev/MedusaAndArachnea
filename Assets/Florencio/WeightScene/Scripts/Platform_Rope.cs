using UnityEngine;
public class Platform_Rope : MonoBehaviour
{
    [SerializeField] private Transform idle;
    [SerializeField] private Transform pulled;
    [SerializeField] private Transform user;
    private float platformSpeed = 1f;
    private float stopDistance = 0.01f;
    private Vector3 idlePos;
    private Vector3 pulledPos;
    private Vector3 currentTarget;
    private bool ropeActive;
    private bool isArachneaUser;
    private void Awake()
    {
        idlePos = idle.position;
        pulledPos = pulled.position;
        currentTarget = idlePos;
        transform.position = idlePos;
        isArachneaUser = user.GetComponent<Arachnea>() != null;
    }
    private void Update()
    {
        if(!isArachneaUser)
        {
            ropeActive = false;
        }
        if(ropeActive)
        {
            currentTarget = pulledPos;
        }
        else
        {
            currentTarget = idlePos;
        }
        Move();
    }
    public void SetRopeActive(bool active)
    {
        if(isArachneaUser)
        {
            ropeActive = active;
        }
        else
        {
            ropeActive = false;
        }
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, platformSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentTarget) <= stopDistance)
        {
            transform.position = currentTarget;
        }
    }
}