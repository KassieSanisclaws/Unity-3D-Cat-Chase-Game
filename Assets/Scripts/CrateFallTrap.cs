using UnityEngine;
using UnityEngine.SceneManagement;

public class CrateFallTrap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player crushed by falling trap!");
            SceneManager.LoadScene("Game Over");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered the crate fall trap!");
            // Additional logic for triggering the crate fall can be added here
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
