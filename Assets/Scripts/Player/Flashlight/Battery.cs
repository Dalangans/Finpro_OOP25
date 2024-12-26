using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public int batteryIncreaseAmount = 10;  // Jumlah daya baterai yang ditambahkan saat pickup
    //public Text batteryText;  // Referensi UI Text untuk menampilkan daya baterai
    public int playerBattery = 100;  // Daya baterai player, mulai dari 100

    // Fungsi untuk mendeteksi tabrakan dengan player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Akses baterai utama dari player
            if (Player.Instance != null)
            {
                Player.Instance.batteryLife += batteryIncreaseAmount;

                // Batasi baterai maksimal 100
                if (Player.Instance.batteryLife > 100)
                    Player.Instance.batteryLife = 100;

                Debug.Log("Battery increased to: " + Player.Instance.batteryLife);
            }

            Destroy(gameObject); // Hancurkan baterai
        }
    }

    private void AddBattery(int increaseAmount)
    {
        playerBattery += increaseAmount;
        if (playerBattery > 100) playerBattery = 100;
        //UpdateBatteryUI();
    }

    /*private void UpdateBatteryUI()
    {
        if (batteryText != null) batteryText.text = "Battery: " + playerBattery + "%";
    }*/
}
