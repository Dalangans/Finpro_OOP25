using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Kecepatan pergerakan player
    public int battery = 100;     // Daya baterai player
    public int batteryIncrease = 10;  // Jumlah baterai yang bertambah saat tabrakan
    public Text batteryText;  // Referensi UI Text untuk menampilkan daya baterai flashlight

    private Rigidbody2D rb;  // Referensi Rigidbody2D untuk pergerakan
    private Vector2 movement;  // Vektor pergerakan player

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Mendapatkan referensi Rigidbody2D

        // Inisialisasi UI baterai
        UpdateBatteryUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Mendapatkan input pergerakan horizontal (A/D atau kiri/kanan) dan vertikal (W/S atau atas/bawah)
        float horizontalInput = Input.GetAxis("Horizontal");  // A/D atau kiri/kanan
        float verticalInput = Input.GetAxis("Vertical");      // W/S atau atas/bawah

        // Membuat vektor gerakan berdasarkan input
        movement = new Vector2(horizontalInput, verticalInput);
    }

    // FixedUpdate digunakan untuk pergerakan fisika
    void FixedUpdate()
    {
        // Menggerakkan player berdasarkan input yang telah disesuaikan (menghindari rotasi)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Fungsi untuk mendeteksi tabrakan dengan objek yang memiliki tag "Battery"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika player bertabrakan dengan objek yang memiliki tag "Battery"
        if (collision.gameObject.CompareTag("Battery"))
        {
            // Menambahkan daya baterai saat tabrakan terdeteksi
            AddBattery(batteryIncrease);

            // Menampilkan pesan debug untuk menunjukkan perubahan daya baterai
            Debug.Log("Daya baterai bertambah! Daya baterai sekarang: " + battery);

            // Menghancurkan objek baterai setelah tabrakan (opsional)
            Destroy(collision.gameObject);
        }
    }

    // Fungsi untuk menambah daya baterai
    void AddBattery(int increaseAmount)
    {
        battery += increaseAmount;

        // Membatasi baterai tidak melebihi 100
        if (battery > 100)
        {
            battery = 100;
        }

        // Memperbarui UI baterai
        UpdateBatteryUI();
    }

    // Fungsi untuk memperbarui UI daya baterai
    void UpdateBatteryUI()
    {
        if (batteryText != null)
        {
            batteryText.text = "Battery: " + battery + "%";
        }
    }
}
