using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class Key : MonoBehaviour
{
    public Text keyStatusText;  // Referensi ke UI Text untuk menampilkan status apakah player sudah mendapatkan key
    public bool hasKey = false; // Status apakah player sudah memiliki key atau belum
    public Vector2 spawnPosition;  // Posisi spawn Key

    // Referensi ke GameObject Grid, yang berisi Door dan DoorOpen
    public GameObject Grid;        // GameObject yang berisi Door dan DoorOpen

    private GameObject Door;       // GameObject Door yang akan dinonaktifkan
    private GameObject DoorOpen;   // GameObject DoorOpen yang akan diaktifkan

    // Start is called before the first frame update
    void Start()
    {
        // Menetapkan posisi Key di spawnPosition yang telah ditentukan
        transform.position = spawnPosition;

        // Memperbarui UI status Key
        UpdateKeyUI();

        // Mencari Door dan DoorOpen dalam GameObject Grid
        if (Grid != null)
        {
            // Mengambil referensi ke Door dan DoorOpen dari objek Grid
            Door = Grid.transform.Find("Door")?.gameObject;       // Menggunakan ? untuk null-check
            DoorOpen = Grid.transform.Find("DoorOpen")?.gameObject; // Menggunakan ? untuk null-check

            // Jika Door atau DoorOpen tidak ditemukan, tampilkan pesan error
            if (Door == null || DoorOpen == null)
            {
                Debug.LogError("Door or DoorOpen not found in the Grid object!");
            }
        }
        else
        {
            Debug.LogError("Grid GameObject is not assigned in the inspector!");
        }
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

            // Mengubah status GameObject Door dan DoorOpen jika keduanya ada
            if (Door != null && DoorOpen != null)
            {
                // Menonaktifkan Door (jika sebelumnya aktif) dan mengaktifkan DoorOpen
                Door.SetActive(false);
                DoorOpen.SetActive(true);
                Debug.Log("Door has been deactivated and DoorOpen has been activated.");
            }
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
