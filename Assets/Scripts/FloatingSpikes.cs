using UnityEngine;
using UnityEngine.SceneManagement; 

public class FloatingSpikes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the floating spikes trigger zone.");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered floating spikes trigger zone! Player will be damaged.");
            SceneManager.LoadScene("Game Over");

            // Here you would typically call a method to damage the player
            // For example: PlayerHealth.Instance.TakeDamage(damageAmount);
            
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
