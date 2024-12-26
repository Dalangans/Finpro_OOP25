using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For Text UI elements
using UnityEngine.Rendering.Universal; // For Light2D

public class Flashlight : MonoBehaviour
{
    public Transform player;              // Pemain
    public Light2D flashlightLight;       // Komponen Light2D untuk flashlight
    public Text batteryText;              // Referensi ke UI baterai
    public float batteryDrainRate = 5f;   // Kecepatan baterai habis (per detik)
    public KeyCode toggleKey = KeyCode.F; // Tombol untuk menyalakan/mematikan flashlight
    

    private bool isOn = false;            // Status flashlight (nyala/mati)

    void Start()
    {
        if (flashlightLight != null)
        {
            flashlightLight.enabled = false; // Matikan flashlight di awal
        }

        if (batteryText != null)
        {
            UpdateBatteryUI(); // Tampilkan level baterai awal
        }
    }

    void Update()
    {
        // Nyalakan/matikan flashlight saat tombol toggleKey ditekan
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleFlashlight();
        }

        // Kurangi baterai jika flashlight menyala
        if (isOn)
        {
            DrainBattery();
        }
    }

    void ToggleFlashlight()
    {
        if (Player.Instance.batteryLife > 0) // Hanya nyalakan jika baterai cukup
        {
            isOn = !isOn;
            flashlightLight.enabled = isOn; // Hidupkan/matikan Light2D
        }
        else
        {
            Debug.LogWarning("Battery is dead! Flashlight cannot be turned on.");
        }
    }

    void DrainBattery()
    {
        if (Player.Instance.batteryLife > 0)
        {
            // Kurangi baterai secara bertahap
            Player.Instance.batteryLife -= batteryDrainRate * Time.deltaTime;

            // Jika baterai habis, matikan flashlight
            if (Player.Instance.batteryLife <= 0)
            {
                Player.Instance.batteryLife = 0;
                flashlightLight.enabled = false;
                isOn = false;
                Debug.LogWarning("Battery is dead! Flashlight turned off.");
            }

            // Perbarui UI
            UpdateBatteryUI();
        }
    }

    void UpdateBatteryUI()
    {
        if (batteryText != null)
        {
            batteryText.text = "Battery: " + Mathf.CeilToInt(Player.Instance.batteryLife) + "%";
        }
    }
}