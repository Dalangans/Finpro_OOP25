using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;  // Add this for scene management

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscareImage; // Objek gambar jumpscare (UI Image atau SpriteRenderer)
    private AudioSource audioSource;

    void Start()
    {
        // Pastikan gambar dan suara sudah diatur
        if (jumpscareImage != null) jumpscareImage.SetActive(false);

        // Pastikan AudioSource terhubung dan ada sound yang valid
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource tidak ditemukan di objek ini!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang bertabrakan adalah Player
        if (other.CompareTag("Player"))
        {
            // Menampilkan gambar jumpscare jika objek gambar ada
            if (jumpscareImage != null)
            {
                jumpscareImage.SetActive(true); // Tampilkan gambar jumpscare
            }

            // Pastikan suara dapat diputar
            if (audioSource != null)
            {
                audioSource.Play(); // Play the jumpscare sound
            }
            else
            {
                Debug.LogError("Jumpscare sound not assigned or AudioSource not available!");
            }

            Debug.Log("Jumpscare triggered!");
            StartCoroutine(HideJumpscare());
        }
    }

    private IEnumerator HideJumpscare()
    {
        // Tunggu 2 detik sebelum menyembunyikan gambar
        yield return new WaitForSeconds(2f);

        if (jumpscareImage != null)
        {
            jumpscareImage.SetActive(false); // Sembunyikan gambar jumpscare
        }

        Debug.Log("Jumpscare ended.");

        // Load the "Dead" scene
        SceneManager.LoadScene("Died");  // This will load the "Dead" scene
    }
}
