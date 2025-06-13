using UnityEngine;

public class PlayerCaught : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the object collided with is tagged as "Enemy"
        {
            Debug.Log("Player caught by enemy!"); // Log a message to the console
            // Here you can add code to handle what happens when the player is caught, e.g., reset the level, show a game over screen, etc.
            // For example, you could reload the current scene:
            // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
