using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySpawner : MonoBehaviour
{
    public GameObject batteryPrefab;  // Prefab objek Battery yang akan di-spawn
    public float spawnInterval = 5f;  // Interval waktu untuk spawn Battery (detik)
    public Vector2 spawnAreaMin;  // Batas minimum spawn area (koordinat X dan Y)
    public Vector2 spawnAreaMax;  // Batas maksimum spawn area (koordinat X dan Y)

    private void Start()
    {
        // Mulai coroutine untuk spawn Battery setiap interval waktu
        StartCoroutine(SpawnBatteryRoutine());
    }

    // Coroutine untuk spawn Battery setiap interval waktu
    private IEnumerator SpawnBatteryRoutine()
    {
        while (true)
        {
            // Spawn objek Battery di posisi acak
            SpawnBattery();

            // Tunggu sesuai dengan interval spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Fungsi untuk spawn objek Battery di posisi acak dalam area tertentu
    private void SpawnBattery()
    {
        // Menentukan posisi acak dalam spawn area yang ditentukan
        float spawnPosX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnPosY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Membuat objek Battery baru di posisi acak
        Vector2 spawnPosition = new Vector2(spawnPosX, spawnPosY);
        Instantiate(batteryPrefab, spawnPosition, Quaternion.identity);
    }
}
