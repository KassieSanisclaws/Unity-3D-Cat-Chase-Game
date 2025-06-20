using UnityEngine;

public class LaunchPadTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something/Player entered the launch pad trigger zone.");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered launch pad trigger zone! Launching player.");
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 launchForce = new Vector3(10, 20, 0); // Adjust the force vector as needed
                playerRb.AddForce(launchForce, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("Player Rigidbody not found!");
            }
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
