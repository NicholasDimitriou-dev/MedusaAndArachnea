using System;
using UnityEngine;
using UnityEngine.AI;
public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 openOffset;
    [SerializeField] private float speed = 2f;
    private AudioSource audioSource;


    // Added 
    [SerializeField] private EnemyMovement_NoNavMesh e;
    [SerializeField] private EnemyMovement_NoNavMesh2 e2;
    //
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * speed);
        }
    }

    public void SetOpen(bool open)
    {
        audioSource.Play();
        isOpen = open;

        //Added
        if (e != null || e2 != null)
        {
            e.SetDoorOpen(isOpen);
        }
        //
    }
}
