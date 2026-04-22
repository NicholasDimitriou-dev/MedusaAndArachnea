using System;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    [SerializeField] private Enemy enemy;

    private void Start() {
        enemy.transform.position = position1.position;
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1,
            enemy.transform.position.z);
    }

    public Transform GetPositionOne()
    {
        return position1;
    }
    
    public Transform GetPositionTwo()
    {
        return position2;
    }
}
