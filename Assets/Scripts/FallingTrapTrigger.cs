using UnityEngine;

public class FallingTrapTrigger : MonoBehaviour
{
    public Rigidbody fallingCrateRb;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger zone.");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone! Crate will now fall.");
            if (fallingCrateRb != null)
            {
                fallingCrateRb.isKinematic = false; // enable gravity fall
            }
            else
            {
                Debug.LogWarning("Falling crate Rigidbody not assigned!");
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
