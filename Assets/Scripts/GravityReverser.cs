using UnityEngine;

public class GravityReverser : MonoBehaviour
{
    private Vector3 originalGravity;

    private void Start()
    {
        // Store original gravity at game start
        originalGravity = Physics.gravity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gravity reversed!");
            Physics.gravity = new Vector3(0, 279f, 0); // Pulls player UP
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gravity restored.");
            Physics.gravity = originalGravity; // Reset gravity
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
