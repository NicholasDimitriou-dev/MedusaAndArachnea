using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void TurnToStone(Transform stonePrefab)
    {
        var obj = Instantiate(stonePrefab);
        obj.transform.position = transform.position;
        Destroy(gameObject);
    }
}
