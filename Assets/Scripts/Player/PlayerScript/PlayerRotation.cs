using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Transform m_transform;  // Transform untuk rotasi player

    // Start is called before the first frame update
    private void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        Aim();  // Memanggil Aim() setiap frame untuk rotasi
    }

    private void Aim()
    {
        // Mendapatkan posisi mouse dalam dunia
        Vector2 direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)m_transform.position;

        // Menghitung rotasi yang diperlukan untuk menghadap ke mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Mengatur rotasi player (hanya sumbu Z yang berubah) untuk body aiming
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        // Memutar tubuh player untuk menghadap ke mouse, tetapi tidak mengubah pergerakan
        m_transform.rotation = rotation;
    }
}
