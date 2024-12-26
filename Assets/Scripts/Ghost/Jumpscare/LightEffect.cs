using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightEffect : MonoBehaviour
{
    public Light2D playerLight;          // Referensi ke Light2D pemain
    public float scareIntensity = 0.2f; // Intensitas lampu saat jumpscare
    public Color scareColor = Color.red; // Warna lampu saat jumpscare
    public float effectDuration = 2f;   // Durasi efek jumpscare
    private float originalIntensity;    // Intensitas awal lampu
    private Color originalColor;        // Warna awal lampu

    void Start()
    {
        // Simpan intensitas awal dan warna lampu
        if (playerLight != null)
        {
            originalIntensity = playerLight.intensity;
            originalColor = playerLight.color;
        }
        else
        {
            Debug.LogError("Player Light2D is not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggering jumpscare light effect!");
            StartCoroutine(TriggerJumpscareLight());
        }
    }

    private IEnumerator TriggerJumpscareLight()
    {
        if (playerLight != null)
        {
            // Ubah intensitas dan warna ke efek jumpscare
            playerLight.intensity = scareIntensity;
            playerLight.color = scareColor;

            // Tunggu selama durasi jumpscare
            yield return new WaitForSeconds(effectDuration);

            // Kembalikan intensitas dan warna ke kondisi awal
            playerLight.intensity = originalIntensity;
            playerLight.color = originalColor;

            Debug.Log("Jumpscare light effect ended.");
        }
    }
}

