using UnityEngine;

public class Medusa : Player
{
    [SerializeField] private Transform enemyStonePrefab;

    public override void Interact()
    {
        Vector3 dir;
        float interactDistance = 5f;
        if (direction >= 0f)
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
            
            if (raycastHit.transform.TryGetComponent(out Enemy enemy))
            {
                // Transform location = enemy.gameObject.GetComponent<Transform>();
                enemy.TurnToStone(enemyStonePrefab);
                
                

            }
        }
    }
}
