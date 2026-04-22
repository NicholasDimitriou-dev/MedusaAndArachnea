using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
    // Sometimes crash, fix later (Players)
    private bool isOnCooldown = false;

    public void Interact()
    {
        if (!isOnCooldown)
        {
            elevator.ActivateElevator();
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
