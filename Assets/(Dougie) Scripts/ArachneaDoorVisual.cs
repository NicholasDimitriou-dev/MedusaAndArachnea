using System;
using UnityEngine;

public class ArachneaDoorVisual : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private IndividualDoor parentDoor;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource closeAudioSource;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        parentDoor.ArachnaeOnDoor += ParentDoor_OnEntrance;
        parentDoor.ArachnaeOffDoor += ParentDoor_OnExit;
    }

    private void ParentDoor_OnExit(object sender, EventArgs e)
    {
        closeAudioSource.Play();
        animator.SetTrigger("Close");
    }

    private void ParentDoor_OnEntrance(object sender, EventArgs e)
    {
        audioSource.Play();
        animator.SetTrigger("Open");
    }
}
