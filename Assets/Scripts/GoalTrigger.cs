using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace to manage scenes

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object entering the trigger is tagged as "Player"
        {
            Debug.Log("Goal Reached!"); // Log a message to the console
            // Here you can add code to handle what happens when the player reaches the goal, e.g., load a new scene, show a message, etc.
            // Load next scene/ Win Scene
            // UnityEngine.SceneManagement.SceneManager.LoadScene("NextSceneName"); // Uncomment and replace "NextSceneName" with your scene name
            // Or you can call a method to handle the win condition

            GameStats.score += 100; // Increment the score by 100 when the player reaches the goal
            // Load Scene Win Scene
            SceneManager.LoadScene("WinScene"); // Load the Win Scene when the player reaches the goal
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
