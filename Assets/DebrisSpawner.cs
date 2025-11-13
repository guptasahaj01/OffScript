using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    // Drag your "Debristemplate" prefab here in the Inspector
    public GameObject debrisPrefab; 
    private bool isSpawning = true;

    // How often to spawn a new debris (in seconds)
    public float spawnRate = 1.0f;

    // How wide the spawn area is
    public float spawnAreaWidth = 10f;

    private float nextSpawnTime;

    void Update()
    {
        // First, check if spawning is allowed
        if (isSpawning)
        {
            // If it is, then check the timer
            if (Time.time > nextSpawnTime)
            {
                SpawnDebris();
                nextSpawnTime = Time.time + spawnRate;
            }
        }
    }

    void SpawnDebris()
    {
        // Get the spawner's current position
        Vector2 spawnerPosition = transform.position;

        // Calculate a random horizontal position within the spawn area
        float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);

        // Set the final spawn position
        Vector2 spawnPosition = new Vector2(spawnerPosition.x + randomX, spawnerPosition.y);

        // Create the new debris object at the calculated position
        Instantiate(debrisPrefab, spawnPosition, Quaternion.identity);
    }

    // --- THIS IS NOW INSIDE THE CLASS ---
    // The GameManager can call this function to stop the spawner.
    public void StopSpawning()
    {
        isSpawning = false;
    }
}