using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{// Fungsi untuk memuat scene tertentu
    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadSceneAsync(sceneName);
    }

    // Fungsi untuk memuat scene "GameLoop"
    public void GameLoop()
    {
        LoadScene("GameLoop");
    }

    // Fungsi untuk keluar dari aplikasi
    public void QuitApplication()
    {
        Debug.Log("Quitting application...");
        Application.Quit();
    }
}
