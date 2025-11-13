using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Event Triggers")]
    public int scoreToTriggerEvent = 1; // When to start the dialogue

    [Header("Game Object References")]
    public DebrisSpawner debrisSpawner;
    public BarrelSpawner barrelSpawner;
    public DialogueManager dialogueManager;

    [Header("Event Dialogue")]
    public Dialogue heroVsVillainDialogue;

    private int playerScore = 0;
    private bool hasTriggeredDialogue = false;

    void Start()
    {
        // ❌ Removed auto-start dialogue
        // No dialogue will play when game starts
    }

    void Update()
    {
        // Trigger dialogue once when score reaches threshold
        if (!hasTriggeredDialogue && playerScore >= scoreToTriggerEvent)
        {
            Debug.Log("Score threshold reached! Starting dialogue...");
            dialogueManager.StartDialogue(heroVsVillainDialogue);
            hasTriggeredDialogue = true;
        }
    }

    // Called by debris pieces or barrels when cleared
    public void AddScore(int amount)
    {
        playerScore += amount;
        Debug.Log("Player Score: " + playerScore);
    }
}