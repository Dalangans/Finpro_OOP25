using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public GameObject batteryPrefab;      // Prefab baterai yang akan di-spawn
    public float spawnInterval = 5f;      // Interval waktu untuk spawn baterai
    public Vector2 spawnAreaMin;          // Batas minimum area spawn (koordinat X dan Y)
    public Vector2 spawnAreaMax;          // Batas maksimum area spawn (koordinat X dan Y)
    public LayerMask wallLayer;           // LayerMask untuk mendeteksi tembok

    private void Start()
    {
        // Mulai rutinitas untuk spawn baterai secara berkala
        StartCoroutine(SpawnBatteryRoutine());
    }

    private IEnumerator SpawnBatteryRoutine()
    {
        while (true)
        {
            SpawnBattery(); // Spawn baterai baru
            yield return new WaitForSeconds(spawnInterval); // Tunggu sebelum spawn berikutnya
        }
    }

    private void SpawnBattery()
    {
        Vector2 spawnPosition;
        int maxAttempts = 10; // Maksimal percobaan untuk mencari lokasi yang valid

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            // Tentukan posisi acak di area spawn
            float spawnPosX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float spawnPosY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            spawnPosition = new Vector2(spawnPosX, spawnPosY);

            // Periksa apakah lokasi ini tidak bertabrakan dengan tembok
            if (!Physics2D.OverlapCircle(spawnPosition, 0.5f, wallLayer))
            {
                // Jika lokasi valid, spawn baterai di sini
                Instantiate(batteryPrefab, spawnPosition, Quaternion.identity);
                return;
            }
        }

        Debug.LogWarning("Failed to find a valid spawn location for the battery.");
    }
}