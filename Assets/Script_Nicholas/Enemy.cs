using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    [SerializeField] private EnemyPath enemyPath;
    private Transform destination;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = enemyPath.GetPositionTwo();
    }


    private void Update()
    {
        agent.SetDestination(destination.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destination One"))
        {
            destination = enemyPath.GetPositionTwo();
        }
        else if (other.CompareTag("Destination Two"))
        {
            destination = enemyPath.GetPositionOne();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit a player!");
            Destroy(other.gameObject);
        }
    }


    public void TurnToStone(Transform stonePrefab)
    {
        var obj = Instantiate(stonePrefab);
        obj.transform.position = transform.position;
        Destroy(gameObject);
    }
}
