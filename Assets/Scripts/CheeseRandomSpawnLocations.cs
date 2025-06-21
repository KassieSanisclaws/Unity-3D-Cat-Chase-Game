using UnityEngine;
using System.Collections;

public class CheeseRandomSpawnLocations : MonoBehaviour
{
    public Transform[] spawnPoints;     // Assign in Inspector
    public float teleportInterval = 35f;
    public float floatAmplitude = 0.5f;
    public float floatFrequency = 1f;

    public ParticleSystem teleportEffect; // Assign in Inspector  

    private float baseY; // Base Y position for floating effect  
    private int currSpawnIndx = -1;
    private float currentHoverY;
    private AudioSource audioSource; // Audio source for teleport sound  

    // Start is called once before the first execution of Update after the MonoBehaviour is created  
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        baseY = transform.position.y;
        MoveToRandomSpawn(); // Initial position  
        StartCoroutine(SwitchPositionRoutine());
    }

    // Update is called once per frame  
    void Update()
    {
        float targetY = baseY + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        currentHoverY = Mathf.Lerp(currentHoverY, targetY, Time.deltaTime * 5f); // Smooth transition
        transform.position = new Vector3(transform.position.x, currentHoverY, transform.position.z);
    }

    IEnumerator SwitchPositionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);
            MoveToRandomSpawn();
        }
    }

    void MoveToRandomSpawn()
    {
        if (spawnPoints.Length == 0) return;

        int newIndex;
        do
        {
            newIndex = Random.Range(0, spawnPoints.Length);
        } while (newIndex == currSpawnIndx); // Avoid repeating last location  

        currSpawnIndx = newIndex;
        Transform chosen = spawnPoints[currSpawnIndx];

        baseY = chosen.position.y;
        transform.position = chosen.position;
        
        if(teleportEffect != null) teleportEffect.Play();
        if (audioSource != null) audioSource.Play(); // Fixed teleport sound  
    }
}
