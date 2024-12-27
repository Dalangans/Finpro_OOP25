using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class Player : MonoBehaviour
{
    // Mendeklarasikan instance statis untuk Singleton
    public static Player Instance;
    public float batteryLife = 100f;  // Daya baterai player
    public bool hasKey = false; 

    public Text batteryText;  // Referensi UI Text untuk menampilkan daya baterai flashlight

    // Start is called before the first frame update
    void Start()
    {
        // Jika instance belum ada, set instance ini sebagai satu-satunya objek player
        if (Instance == null)
        {
            Instance = this;
            // Menjaga agar instance tidak dihancurkan saat scene berubah
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika sudah ada instance lain, hancurkan objek ini
            Destroy(gameObject);
        }

        // Inisialisasi UI baterai
        UpdateBatteryUI();
    }

    // Fungsi untuk memperbarui UI daya baterai
    public void UpdateBatteryUI()
    {
        if (batteryText != null)
        {
            batteryText.text = "Battery: " + batteryLife + "%";
        }
    }

    // Fungsi untuk menambah daya baterai
    public void AddBattery(int increaseAmount)
    {
        batteryLife += increaseAmount;

        // Membatasi baterai tidak melebihi 100
        if (batteryLife > 100)
        {
            batteryLife = 100;
        }

        // Memperbarui UI baterai
        UpdateBatteryUI();
    }
}
