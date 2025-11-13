using UnityEngine;

public class BackgroundEffectsManager : MonoBehaviour
{
    [Header("Effects")]
    public GameObject[] effects;      // Fireball, Laser, Explosion... etc.

    [Header("Spawn Settings")]
    public float spawnInterval = 3f;  // One effect every X seconds
    public float minX = -12f;
    public float maxX = 12f;
    public float spawnY = 10f;        // Height to spawn above the scene

    private float timer;
    private bool isActive = true;

    void Update()
    {
        if (!isActive) 
            return;

        timer += Time.unscaledDeltaTime; // uses unscaled in case timeScale = 0 later

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnRandomEffect();
        }
    }

    /// <summary>
    /// Safely spawns a random background effect.
    /// </summary>
    void SpawnRandomEffect()
    {
        if (effects == null || effects.Length == 0)
        {
            Debug.LogWarning("BackgroundEffectsManager: No effects assigned!");
            return;  // Prevents crashes
        }

        int rand = Random.Range(0, effects.Length);
        GameObject prefab = effects[rand];

        Vector3 spawnPos = new Vector3(
            Random.Range(minX, maxX),
            spawnY,
            0
        );

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    /// <summary>
    /// Stops spawning effects (freeze event).
    /// </summary>
    public void StopSpawning()
    {
        isActive = false;
    }

    /// <summary>
    /// Resumes spawning effects (after dialogue).
    /// </summary>
    public void StartSpawning()
    {
        isActive = true;
        timer = 0f; // restart timer clean
    }
}