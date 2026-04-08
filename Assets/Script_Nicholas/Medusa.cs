using UnityEngine;

public class Medusa : MonoBehaviour
{
    [SerializeField] private Transform enemyStonePrefab;
    private void Interact()
    {
        float interactDistance = 5f;
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit raycastHit, interactDistance))
        {
            if (raycastHit.transform.TryGetComponent(out Enemy enemy))
            {
                Destroy(enemy.gameObject);
                Instantiate(enemyStonePrefab);

            }
        }
    }
}
