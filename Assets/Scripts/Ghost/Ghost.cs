using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;       // Reference to the player's Transform
    public Flashlight flashlight;  // Reference to the Flashlight script
    public float speed = 5f;       // Base movement speed
    public float reducedSpeed = 2f; // Reduced speed when flashlight is on
    public float stoppingDistance = 1f;  // Minimum distance to stop following
    public bool allowDiagonal = true;   // Allow diagonal movement

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            float distance = Vector3.Distance(transform.position, player.position);

            float currentSpeed = (flashlight != null && flashlight.IsFlashlightOn()) ? reducedSpeed : speed;

            if (distance > stoppingDistance)
            {
                if (!allowDiagonal)
                {
                    direction = RestrictToVerticalOrHorizontal(direction);
                }

                transform.position += direction * currentSpeed * Time.deltaTime;
            }
        }
    }

    Vector3 RestrictToVerticalOrHorizontal(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            direction.y = 0;
        }
        else
        {
            direction.x = 0;
        }

        return direction.normalized;
    }
}
