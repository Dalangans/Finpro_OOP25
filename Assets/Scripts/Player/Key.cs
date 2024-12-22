using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class Key : MonoBehaviour
{
    public Text keyStatusText;  // Referensi ke UI Text untuk menampilkan status apakah player sudah mendapatkan key
    public bool hasKey = false; // Status apakah player sudah memiliki key atau belum
    public Vector2 spawnPosition;  // Posisi spawn Key

    // Start is called before the first frame update
    void Start()
    {
        // Menetapkan posisi Key di spawnPosition yang telah ditentukan
        transform.position = spawnPosition;

        // Memperbarui UI status Key
        UpdateKeyUI();
    }

    // Fungsi untuk mendeteksi tabrakan dengan player
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Periksa apakah objek yang bertabrakan adalah player
        if (other.CompareTag("Player"))
        {
            // Menandai bahwa player telah mengambil key
            hasKey = true;

            // Menampilkan pesan debug untuk menunjukkan bahwa player telah mengambil key
            Debug.Log("Player has picked up the Key!");

            // Menghancurkan objek key setelah diambil
            Destroy(gameObject);

            // Memperbarui status UI key
            UpdateKeyUI();
        }
    }

    // Fungsi untuk memperbarui status UI apakah player sudah mengambil key
    private void UpdateKeyUI()
    {
        if (keyStatusText != null)
        {
            keyStatusText.text = hasKey ? "Key: Collected" : "Key: Not Collected";
        }
    }
}
