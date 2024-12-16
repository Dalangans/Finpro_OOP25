using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Mendeklarasikan instance statis untuk Singleton
    public static Player Instance;

    // Start is called before the first frame update
    void Start()
    {
        // Jika instance belum ada, set instance ini sebagai satu-satunya objek player
        if (Instance == null)
        {
            Instance = this;
            // Menjaga agar instance tidak dihancurkan saat scene berubah
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika sudah ada instance lain, hancurkan objek ini
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Tambahkan logika update player di sini
    }
}
