using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Transform player;  // Referensi ke objek player

    // Start is called before the first frame update
    void Start()
    {
        // Cek jika player belum di-set
        if (player == null)
        {
            Debug.LogError("Player not assigned in the Flashlight script!");
        }
        else
        {
            // Pastikan flashlight menjadi anak dari player sehingga mengikuti pergerakan player secara otomatis
            transform.SetParent(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Memastikan flashlight mengikuti rotasi player
        RotateFlashlight();
    }

    // Fungsi untuk memutar flashlight agar sesuai dengan rotasi sprite player
    void RotateFlashlight()
    {
        if (player != null)
        {
            // Flashlight mengikuti rotasi player
            transform.rotation = player.rotation; 
        }
    }
}
