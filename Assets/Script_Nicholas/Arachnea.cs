using System;
using Unity.VisualScripting;
using UnityEngine;

public class Arachnea : Player
{

    // public float gravMod = 1f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Interact()
    {
        if (isOnWall)
        {
            gravityMod = 1f;
            isOnWall = false;
        }
        else
        {
            if (wallClimb())
            {
                gravityMod = 0f;
                isOnWall = true;
            }
            else
            {
                gravityMod = 1f;
                isOnWall = false;
            }
        }

    }

    private bool wallClimb()
    {
        float interactDistance = 2f;
        Debug.DrawRay(transform.position, Vector3.left* interactDistance, Color.greenYellow);
        Debug.DrawRay(transform.position, Vector3.right * interactDistance, Color.greenYellow);
        if (Physics.Raycast(transform.position, Vector3.left, out RaycastHit raycastHit, interactDistance))
        {
            
            if (raycastHit.transform.TryGetComponent(out Wall wall))
            {
                return true;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out RaycastHit raycastHitright, interactDistance))
        {
           
            if (raycastHitright.transform.TryGetComponent(out Wall wall))
            {
                return true;
            }
        }
        return false;
        
    }

}
