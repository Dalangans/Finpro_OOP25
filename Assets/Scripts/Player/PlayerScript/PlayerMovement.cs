using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Kecepatan pergerakan player

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

        // Tidak ada pembatasan posisi, jadi kita tidak menggunakan Mathf.Clamp
    }
}
