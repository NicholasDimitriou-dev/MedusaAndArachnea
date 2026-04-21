using System;
using UnityEngine;

public class ArachneaDoorVisual : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private IndividualDoor parentDoor;
    
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
        animator.SetTrigger("Close");
    }

    private void ParentDoor_OnEntrance(object sender, EventArgs e)
    {
        animator.SetTrigger("Open");
    }
}
