using UnityEngine;

public class EnemyBirdAI : MonoBehaviour
{
    public Transform player;               // Player reference
    public float sightRange = 10f;         // How far bird can detect player
    public float moveSpeed = 5f;           // Speed to chase player
    public float hoverAmplitude = 0.5f;    // Vertical float distance
    public float hoverFrequency = 2f;      // Speed of vertical float
    public float rotationSpeed = 5f;

    private float baseHeight;
    private bool isChasing = false;

    //private Vector3 initialPosition;


    void Start()
    {
        //initialPosition = transform.position;
        baseHeight = transform.position.y;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        isChasing = distanceToPlayer <= sightRange;

        // Calculate hover height
        float hoverY = baseHeight + Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;

        if (isChasing)
        {
            // Only move in XZ plane toward player
            Vector3 direction = new Vector3(
                player.position.x - transform.position.x,
                0f,
                player.position.z - transform.position.z
            ).normalized;

            Vector3 move = direction * moveSpeed * Time.deltaTime;

            // Apply movement in XZ + hover in Y
            transform.position += new Vector3(move.x, 0f, move.z);
            transform.position = new Vector3(transform.position.x, hoverY, transform.position.z);

            // Rotate toward player
            if (direction != Vector3.zero)
            {
                Quaternion lookRot = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Idle hover in place
            transform.position = new Vector3(transform.position.x, hoverY, transform.position.z);
        }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //    {

    //    }

    }
}
