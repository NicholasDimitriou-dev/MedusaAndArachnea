using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            GameManager.Instance.AddCoins(value);
            Destroy(gameObject);
        }
    }
}
