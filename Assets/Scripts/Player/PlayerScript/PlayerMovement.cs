using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Kecepatan pergerakan player
    public int batteryIncrease = 10;  // Jumlah baterai yang bertambah saat tabrakan

    private Rigidbody2D rb;  // Referensi Rigidbody2D untuk pergerakan
    private Vector2 movement;  // Vektor pergerakan player
    private Vector2 velocity = Vector2.zero;  // Velocity untuk smooth movement

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Mendapatkan referensi Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        // Mendapatkan input pergerakan horizontal (A/D atau kiri/kanan) dan vertikal (W/S atau atas/bawah)
        float horizontalInput = Input.GetAxis("Horizontal");  // A/D atau kiri/kanan
        float verticalInput = Input.GetAxis("Vertical");      // W/S atau atas/bawah

        // Membuat vektor gerakan berdasarkan input
        movement = new Vector2(horizontalInput, verticalInput).normalized;  // Menormalisasi input untuk pergerakan yang konsisten
    }

    // FixedUpdate digunakan untuk pergerakan fisika
    void FixedUpdate()
    {
        // Jika tidak ada input, atur velocity menjadi 0 untuk menghentikan pergerakan
        if (movement.magnitude == 0)
        {
            rb.velocity = Vector2.zero;  // Menghentikan pergerakan jika tidak ada input
        }
        else
        {
            // Perhalus pergerakan dengan Lerp untuk transisi yang lebih mulus
            rb.velocity = Vector2.SmoothDamp(rb.velocity, movement * moveSpeed, ref velocity, 0.1f);
        }
    }

    // Fungsi untuk mendeteksi tabrakan dengan objek yang memiliki tag "Battery"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika player bertabrakan dengan objek yang memiliki tag "Battery"
        if (collision.gameObject.CompareTag("Battery"))
        {
            // Menambahkan daya baterai saat tabrakan terdeteksi
            Player.Instance.AddBattery(batteryIncrease);

            // Menampilkan pesan debug untuk menunjukkan perubahan daya baterai
            Debug.Log("Daya baterai bertambah! Daya baterai sekarang: " + Player.Instance.batteryLife);

            // Menghancurkan objek baterai setelah tabrakan (opsional)
            Destroy(collision.gameObject);
        }
    }
}
