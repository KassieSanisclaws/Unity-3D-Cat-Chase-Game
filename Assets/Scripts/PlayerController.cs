using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem; // Import the Unity Input System namespace

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions inputActions; // Reference to the Input System actions
    private Vector2 movement; // Store the movement input from the player
    public float movementSpeed = 5f; // Speed of player movement
    private Rigidbody rb; // Reference to the Rigidbody2D component
    
    private void Awake()
    {
        inputActions = new InputSystem_Actions(); // Initialize the Input System actions
        
    }

    private void OnEnable()
    {
        inputActions.Player.Enable(); // Enable the Player actions
        inputActions.Player.Move.performed += OnMove; // Subscribe to the Move action performed event
        inputActions.Player.Move.canceled += OnMove; // Subscribe to the Move action canceled event
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove; // Unsubscribe from the Move action performed event
        inputActions.Player.Move.canceled -= OnMove; // Unsubscribe from the Move action canceled event
        inputActions.Player.Disable(); // Disable the Player actions
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody2D component attached to this GameObject
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>(); // Read the movement input value from the Input System
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal"); // Get horizontal input (A/D keys or Left/Right arrows)
        //float v = Input.GetAxis("Vertical"); // Get vertical input (W/S keys or Up/Down arrows)
        Vector3 move = new Vector3(movement.x, 0f, movement.y); // Create a movement vector based on input
        rb.MovePosition(transform.position + move * movementSpeed * Time.fixedDeltaTime);
    }
}
