using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject gooPrefab;

    [Header("Ground Range")]
    public float minX = -10f;
    public float maxX = 10f;
    public float groundY = -2.5f;

    private GameObject currentGoo;

    public void SpawnGoo()
    {
        if (currentGoo != null)
        {
            Debug.Log("⚠ Goo already exists — not spawning another.");
            return;
        }

        float randX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randX, groundY, 0);

        currentGoo = Instantiate(gooPrefab, spawnPos, Quaternion.identity);

        Debug.Log("🍯 Goo Spawned at: " + spawnPos);
    }

    public void ClearGooReference()
    {
        currentGoo = null;
    }
}