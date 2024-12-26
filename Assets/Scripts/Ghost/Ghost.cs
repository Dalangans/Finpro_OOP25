using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;            // Target pemain
    public float speed = 2f;            // Kecepatan Ghost
    public float stoppingDistance = 1f; // Jarak berhenti

    private Rigidbody2D rb;             // Rigidbody2D Ghost

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on Ghost!");
        }

        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned!");
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Hitung arah menuju pemain
            Vector2 direction = (player.position - transform.position).normalized;

            // Hitung jarak ke pemain
            float distance = Vector2.Distance(transform.position, player.position);

            // Jika Ghost belum mencapai jarak berhenti, bergerak ke arah pemain
            if (distance > stoppingDistance)
            {
                // Gerakkan Ghost dengan Rigidbody2D
                Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.fixedDeltaTime;
                rb.MovePosition(newPosition);
            }
        }
    }
}
