using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private int batteryIncreaseAmount = 10;
    //public Text batteryText;
    public int playerBattery = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Menambahkan daya baterai
            AddBattery(batteryIncreaseAmount);

            // Menampilkan pesan debug untuk menunjukkan perubahan daya baterai
            Debug.Log("Daya baterai bertambah! Daya baterai sekarang: " + playerBattery);

            // Menghancurkan objek baterai setelah diambil
            Destroy(gameObject);
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
