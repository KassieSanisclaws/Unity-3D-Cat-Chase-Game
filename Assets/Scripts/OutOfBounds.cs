using UnityEngine;
using UnityEngine.SceneManagement;

public class OuntOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exited bounds!");
            SceneManager.LoadScene("Game Over"); // Call the GameOver logic
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy has exited bounds!");
            // Logic to bound enemy back to the play area scene              
        }

    }
}
