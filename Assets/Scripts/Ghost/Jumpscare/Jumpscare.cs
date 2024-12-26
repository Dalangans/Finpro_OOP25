using System.Collections;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscareImage; // Objek gambar jumpscare (UI Image atau SpriteRenderer)
    public AudioClip jumpscareSound;  // Efek suara jumpscare
    private AudioSource audioSource;

    void Start()
    {
        // Pastikan gambar dan suara sudah diatur
        if (jumpscareImage != null) jumpscareImage.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (jumpscareImage != null)
            {
                jumpscareImage.SetActive(true); // Tampilkan gambar jumpscare
            }

            if (jumpscareSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpscareSound); // Mainkan suara jumpscare
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
    }
}
