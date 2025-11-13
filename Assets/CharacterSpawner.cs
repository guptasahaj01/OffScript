using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject heroPrefab;
    public GameObject villainPrefab;
    public GameObject npcPrefab;

    [Header("Spawn Points")]
    public Transform heroSpawnPoint;
    public Transform villainSpawnPoint;
    public Transform npcSpawnPoint;

    [HideInInspector] public GameObject heroInstance;
    [HideInInspector] public GameObject villainInstance;
    [HideInInspector] public GameObject npcInstance;

    public void SpawnCharacters()
    {
        // Spawn hero
        if (heroPrefab && heroSpawnPoint)
            heroInstance = Instantiate(heroPrefab, heroSpawnPoint.position, Quaternion.identity);

        // Spawn villain
        if (villainPrefab && villainSpawnPoint)
            villainInstance = Instantiate(villainPrefab, villainSpawnPoint.position, Quaternion.identity);

        // Spawn NPC
        if (npcPrefab && npcSpawnPoint)
            npcInstance = Instantiate(npcPrefab, npcSpawnPoint.position, Quaternion.identity);
    }
}