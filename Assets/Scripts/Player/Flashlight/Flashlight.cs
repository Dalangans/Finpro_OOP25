using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace
 // Import for Light2D

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For Text UI elements
using UnityEngine.Rendering.Universal; // For Light2D

public class Flashlight : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public Light2D flashlightLight;  // Reference to the Light2D component
    public Text batteryText;  // Reference to the UI Text element
    public float batteryLife = 100f;  // Battery life in percentage
    public float batteryDrainRate = 5f;  // Battery drain rate per second
    public KeyCode toggleKey = KeyCode.F;  // Key to toggle the flashlight

    private bool isOn = false;  // State of the flashlight

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned in the Flashlight script!");
        }
        else
        {
            transform.SetParent(player);
        }

        if (flashlightLight == null)
        {
            Debug.LogError("Light2D component not assigned!");
        }
        else
        {
            flashlightLight.enabled = false;  // Turn off the flashlight initially
        }

        if (batteryText == null)
        {
            Debug.LogError("Battery Text UI not assigned!");
        }

        UpdateBatteryUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleFlashlight();
        }

        if (isOn)
        {
            DrainBattery();
        }

        RotateFlashlight();
    }

    void ToggleFlashlight()
    {
        if (batteryLife > 0)
        {
            isOn = !isOn;
            flashlightLight.enabled = isOn;
        }
        else
        {
            Debug.LogWarning("Battery is dead! Flashlight cannot be turned on.");
        }
    }

    void DrainBattery()
    {
        if (batteryLife > 0)
        {
            batteryLife -= batteryDrainRate * Time.deltaTime;

            if (batteryLife <= 0)
            {
                batteryLife = 0;
                flashlightLight.enabled = false;
                isOn = false;
                Debug.LogWarning("Battery is dead! Flashlight turned off.");
            }

            UpdateBatteryUI();
        }
    }

    void RotateFlashlight()
    {
        if (player != null)
        {
            transform.rotation = player.rotation;
        }
    }

    void UpdateBatteryUI()
    {
        if (batteryText != null)
        {
            batteryText.text = "Battery: " + Mathf.CeilToInt(batteryLife) + "%";
        }
    }

    public bool IsFlashlightOn()
    {
        return isOn; // Return the state of the flashlight
    }

    public void RechargeBattery(float amount)
    {
        batteryLife += amount;
        if (batteryLife > 100f)
        {
            batteryLife = 100f;
        }

        UpdateBatteryUI();
    }
}