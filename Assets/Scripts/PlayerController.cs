using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSPeed = 5f; // Speed of player movement
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // Get horizontal input (A/D keys or Left/Right arrows)
        float v = Input.GetAxis("Vertical"); // Get vertical input (W/S keys or Up/Down arrows)
        Vector3 movement = new Vector3(h, v, 0f); // Create a movement vector based on input
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z); // Reset velocity to zero 
    }
}
