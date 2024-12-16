using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;           // Referensi ke objek player
    public Vector2 offset = new Vector2(0, 2);  // Jarak offset antara kamera dan player dalam 2D
    public float smoothSpeed = 0.125f;  // Kecepatan interpolasi

    // Start is called before the first frame update
    void Start()
    {
        // Mencari objek dengan tag "Player"
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform; // Menyimpan referensi transform player
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found!");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            // Menentukan posisi tujuan kamera (mengikuti pergerakan player di sumbu X dan Y)
            Vector2 desiredPosition = new Vector2(player.position.x, player.position.y) + offset;

            // Menentukan posisi kamera yang halus menggunakan lerping
            Vector2 smoothedPosition = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), desiredPosition, smoothSpeed);

            // Mengatur posisi kamera (pastikan sumbu Z tetap)
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
