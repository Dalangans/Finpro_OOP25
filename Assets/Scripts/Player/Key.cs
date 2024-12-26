using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class Key : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.T;      // Tombol yang digunakan untuk pickup
    public Text keyStatusText;          // Referensi UI Text untuk status key
    public GameObject Door;             // Pintu yang akan dibuka
    public GameObject DoorOpen;         // Pintu terbuka yang akan diaktifkan
    private bool isPlayerNearby = false; // Apakah pemain berada di dekat key

    private void Update()
    {
        // Periksa apakah pemain menekan tombol pickup dan berada di dekat key
        if (isPlayerNearby && Input.GetKeyDown(toggleKey))
        {
            PickupKey();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Tandai bahwa pemain berada di dekat key
            Debug.Log("Player is near the key. Press '" + toggleKey + "' to pick it up.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Pemain menjauh dari key
            Debug.Log("Player left the key.");
        }
    }

    private void PickupKey()
    {
        Debug.Log("Key picked up!");
        Player.Instance.hasKey = true; // Tandai bahwa pemain memiliki key

        // Perbarui status UI jika ada
        if (keyStatusText != null)
        {
            keyStatusText.text = "Key: Collected";
        }

        // Buka pintu
        if (Door != null && DoorOpen != null)
        {
            Door.SetActive(false);
            DoorOpen.SetActive(true);
            Debug.Log("Door opened!");
        }

        Destroy(gameObject); // Hancurkan objek key setelah diambil
    }
}
