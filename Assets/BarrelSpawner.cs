using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab; 
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    
    public float moveSpeed = 5f;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 8f;

    [Header("Spawning Conditions")]
    public int scoreToStartSpawning = 50; // Barrels will start after this score
    
    // --- NEW VARIABLE ---
    // The "kill switch" for the GameManager
    private bool canSpawn = true; 

    // This is true once the score is high enough
    private bool spawningActive = false;
    
    private float timer;
    private float timeToSpawn;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        // This is the "kill switch" check. If canSpawn is false,
        // this entire function does nothing.
        if (!canSpawn)
        {
            return; // Stop running the update logic
        }

        // --- This is your score-checking logic ---
        if (spawningActive)
        {
            // --- This part runs AFTER the score is high enough ---
            timer += Time.deltaTime;

            if (timer >= timeToSpawn)
            {
                SpawnBarrel();
                SetNextSpawnTime(); 
                timer = 0;
            }
        }
        else
        {
            // --- This part runs BEFORE the score is high enough ---
            // If spawning is not active, check the global score
            if (PlayerController.score >= scoreToStartSpawning)
            {
                // The score is high enough! Activate the spawner.
                spawningActive = true; 
                Debug.Log("Score limit reached! Releasing the barrels!");
            }
        }
    }

    void SetNextSpawnTime()
    {
        timeToSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void SpawnBarrel()
    {
        int side = Random.Range(0, 2);

        if (side == 0) // Spawn on the left
        {
            GameObject barrel = Instantiate(barrelPrefab, leftSpawnPoint.position, Quaternion.identity);
            barrel.GetComponent<RollingBarrel>().moveSpeed = moveSpeed;
        }
        else // Spawn on the right
        {
            GameObject barrel = Instantiate(barrelPrefab, rightSpawnPoint.position, Quaternion.identity);
            barrel.GetComponent<RollingBarrel>().moveSpeed = -moveSpeed;
        }
    }

    // --- NEW FUNCTION ---
    // The GameManager will call this to stop all spawning
    public void StopSpawning()
    {
        canSpawn = false;
    }
}