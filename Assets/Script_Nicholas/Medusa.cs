using System;
using UnityEngine;
using System.Collections;

public class Medusa : Player
{
    [SerializeField] private Transform enemyStonePrefab;
    [SerializeField] private AudioSource stoneAudioSource;


    // private void Update()
    // {
    //     if (this.gameObject.GetComponent<Player>().getInteract().WasReleasedThisFrame())
    //     {
    //         ToggleDashingSound(false);
    //     }
    // }


    //Animator animatorUsed;
    public void Start()
    {
        //animatorUsed = GetComponent<Player>().GetComponent<Animator>();
    }
    public override void Interact()
    {
        //animatorUsed.SetTrigger("FiredBlast");
        Vector3 dir;
        float interactDistance = 5f;
        if (faceRight)
        {
            dir = Vector3.forward;
        }
        else
        {
            dir = Vector3.back;
        }
        Debug.DrawRay(transform.position, dir*interactDistance, Color.greenYellow);
        if (Physics.Raycast(transform.position, dir, out RaycastHit raycastHit, interactDistance))
        {
            
            if (raycastHit.transform.TryGetComponent(out EnemyMovement_NoNavMesh enemy))
            {
                // Transform location = enemy.gameObject.GetComponent<Transform>();
                stoneAudioSource.Play();
                enemy.TurnToStone(enemyStonePrefab);
                
                

            }
        }
        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, interactDistance))
        {
            if (hit.transform.TryGetComponent(out Lever lever))
            {
                lever.Interact();
            }
        }
    }

}
