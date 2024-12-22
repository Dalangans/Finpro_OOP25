using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;       // Reference to the player's Transform
    public float speed = 5f;       // Movement speed
    public float stoppingDistance = 1f;  // Minimum distance to stop following
    public bool allowDiagonal = true;   // Allow diagonal movement

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Distance between the entity and the player
            float distance = Vector3.Distance(transform.position, player.position);

            // If within stoppingDistance, stop moving
            if (distance > stoppingDistance)
            {
                // If diagonal movement is disabled, move only vertically or horizontally
                if (!allowDiagonal)
                {
                    direction = RestrictToVerticalOrHorizontal(direction);
                }

                // Move toward the player
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    // Restrict the direction vector to vertical or horizontal movement
    Vector3 RestrictToVerticalOrHorizontal(Vector3 direction)
    {
        // Compare absolute values to decide movement direction
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            direction.y = 0;  // Move only horizontally
        }
        else
        {
            direction.x = 0;  // Move only vertically
        }

        return direction.normalized;
    }
}
