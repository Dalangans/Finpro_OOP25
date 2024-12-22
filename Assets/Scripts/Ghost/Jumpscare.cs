using System.Collections;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{

    private Animator jumpscare;

    void Start()
    {

        // Get the Animator component attached to the Ghost
        jumpscare = GetComponent<Animator>();
        if (jumpscare == null)
        {
            Debug.LogError("Animator component not found on the Ghost!");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the Ghost collides with the Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ghost collided with the player. Starting animation.");

            // Trigger the Start animation parameter
            if (jumpscare != null)
            {
                jumpscare.SetTrigger("StartScare");
                StartCoroutine(EndAnimation());
            }
        }
    }

    private IEnumerator EndAnimation()
    {
        // Wait for a while before ending the animation
        yield return new WaitForSeconds(2f);

        if (jumpscare != null)
        {
            jumpscare.SetTrigger("EndScare");
        }

        Debug.Log("Ending animation.");
    }
}
