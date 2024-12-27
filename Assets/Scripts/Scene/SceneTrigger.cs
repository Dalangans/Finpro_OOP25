using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public string sceneToLoad = "EndCredits"; // Nama scene yang akan dimuat

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Panggil fungsi dari MainScene
            MainScene mainScene = FindObjectOfType<MainScene>();
            if (mainScene != null)
            {
                mainScene.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("MainScene script not found!");
            }
        }
    }
}
