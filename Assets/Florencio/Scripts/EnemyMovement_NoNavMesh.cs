using UnityEngine;
public class EnemyMovement_NoNavMesh : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed at which the enemy moves between points
    [SerializeField] private Transform pointA; // Initial starting point
    [SerializeField] private Transform pointB; // Initial target point
    
    private float movementTimer = 0f; // Timer to track waiting time at each point
    
    private bool isMoving = false; // Flag to indicate whether the enemy is currently moving or waiting
    
    private Transform currentTarget; // Current target point the enemy is moving towards
    
    private void Awake()
    {
        transform.position = pointA.position; // Start at point A
        currentTarget = pointB; // Set initial target to point B
    }
    
    private void Update()
    {
        Debug.Log("WaitTimer: " + movementTimer); // Log the current value of the movement timer for debugging purposes
    
        if (!isMoving) // If the enemy is not currently moving, increment the movement timer
        {
            movementTimer += Time.deltaTime; // Increment the movement timer by the time elapsed since the last frame
        
            if (movementTimer >= 3f) // If the movement timer has reached or exceeded 3 seconds, start moving towards the current target
            {
                isMoving = true; // Set the isMoving flag to true to indicate that the enemy is now moving
                movementTimer = 0f; // Reset the movement timer to 0 for the next waiting period after reaching the target
            }
        }
        else
        {
            MoveToPosition(currentTarget); // Move the enemy towards the current target position
        
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f) // If the enemy is close enough to the target position, stop moving and switch to the other target
            {
                isMoving = false; // Set the isMoving flag to false to indicate that the enemy has reached the target and will now wait before moving again
            
                movementTimer = 0f; // Reset the movement timer to 0 for the next waiting period at the new target position
                
                if (currentTarget == pointA) // If the current target is point A, switch to point B as the new target
                {
                    currentTarget = pointB; // Set the current target to point B
                }
                else
                {
                    currentTarget = pointA; // If the current target is not point A (i.e., it is point B), switch to point A as the new target
                }
            }
        }
    }
    
    // Method to move the enemy towards a specified position at a defined speed
    private void MoveToPosition(Transform position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position.position, speed * Time.deltaTime); // Move the enemy's position towards the target position at the defined speed, taking into account the time elapsed since the last frame
    }
}