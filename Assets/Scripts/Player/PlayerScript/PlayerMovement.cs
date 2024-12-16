using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Kecepatan pergerakan player
    private float minX = -10f;    // Batas minimum untuk posisi X
    private float maxX = 9f;      // Batas maksimum untuk posisi X
    private float minY = -7.1f;   // Batas minimum untuk posisi Y
    private float maxY = 7.1f;    // Batas maksimum untuk posisi Y

    // Update is called once per frame
    void Update()
    {
        // Mendapatkan input horizontal (A/D atau kiri/kanan) dan vertikal (W/S atau atas/bawah)
        float horizontalInput = Input.GetAxis("Horizontal");  // A/D atau kiri/kanan
        float verticalInput = Input.GetAxis("Vertical");      // W/S atau atas/bawah

        // Membuat vektor gerakan berdasarkan input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Membalikkan input pergerakan berdasarkan rotasi player (untuk menghindari pengaruh rotasi)
        movement = Quaternion.Inverse(transform.rotation) * movement;

        // Menggerakkan player berdasarkan input pergerakan yang telah disesuaikan
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Membatasi pergerakan player pada sumbu X dan Y
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // Memastikan player tidak keluar dari batas yang ditentukan
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
