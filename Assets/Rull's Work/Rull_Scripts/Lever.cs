using System;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
    // Sometimes crash, fix later (Players)
    private bool isOnCooldown = false;
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip leverOn;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (!isOnCooldown)
        {
            elevator.ActivateElevator();
            audioSource.PlayOneShot(leverOn);
            StartCoroutine(Cooldown());
        }
    }

    private System.Collections.IEnumerator Cooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(1f);
        isOnCooldown = false;
    }
}
