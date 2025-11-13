using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject fireballPrefab;

    public float spawnMinX = -8f;
    public float spawnMaxX = 8f;
    public float spawnHeight = 6f;
    public float spawnRate = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFireball), 1f, spawnRate);
    }

    void SpawnFireball()
    {
        float x = Random.Range(spawnMinX, spawnMaxX);
        Vector3 spawnPos = new Vector3(x, spawnHeight, 0);

        Instantiate(fireballPrefab, spawnPos, Quaternion.identity);
    }
}