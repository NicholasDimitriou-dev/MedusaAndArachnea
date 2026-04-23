using System;
using UnityEngine;

public class IndividualDoor : MonoBehaviour
{
    
    public event EventHandler ArachnaeOnDoor;
    public event EventHandler MedusaOnDoor;
    public event EventHandler ArachnaeOffDoor;
    public event EventHandler MedusaOffDoor;
    
    

    [SerializeField] private DoorsParent doors;  


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arachnea"))
        {
            ArachnaeOnDoor?.Invoke(this, EventArgs.Empty);
        } else if (other.CompareTag("Medusa"))
        {
            MedusaOnDoor?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arachnea"))
        {
            ArachnaeOffDoor?.Invoke(this, EventArgs.Empty);
        } else if (other.CompareTag("Medusa"))
        {
            MedusaOffDoor?.Invoke(this, EventArgs.Empty);
        }
    }
}

