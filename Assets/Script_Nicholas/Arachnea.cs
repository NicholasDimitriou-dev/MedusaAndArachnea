using UnityEngine;

public class Arachnea : MonoBehaviour
{
    private float gravity = 9.8f;

    private bool isOnWall = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Interact()
    {
        if (isOnWall)
        {
            gravity = 9.8f;
            isOnWall = false;
        }
        else
        {
            if (wallClimb())
            {
                gravity = 0f;
                isOnWall = true;
            }
            else
            {
                gravity = 9.8f;
                isOnWall = false;
            }
        }

    }

    private bool wallClimb()
    {
        float interactDistance = 2f;
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
