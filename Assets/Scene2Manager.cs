using UnityEngine;

public class Scene2Manager : MonoBehaviour
{
    [Header("References")]
    public CharacterSpawner characterSpawner;
    public FreezeManager freezeManager;
    public BackgroundEffectsManager bgEffects;
    public PowerupSpawner powerupSpawner;
    public DialogueManager dialogueManager;
    public HeroHealth heroHealth;
    public CameraShake cameraShake;

    [Header("Dialogues")]
    public Dialogue introDialogue;
    public Dialogue gooPhase1Dialogue;
    public Dialogue gooPhase2Dialogue;
    public Dialogue gooPhase3Dialogue;
    public Dialogue finalCutsceneDialogue;

    private int gooPhase = 0;

    void Start()
    {
        characterSpawner.SpawnCharacters();
        bgEffects.StartSpawning();

        // Start intro dialogue after a delay
        Invoke(nameof(StartIntroDialogue), 1f);
    }

    void StartIntroDialogue()
    {
        dialogueManager.StartDialogue(introDialogue);
    }

    public void TriggerGooDialogue()
    {
        freezeManager.Freeze();
        bgEffects.StopSpawning();

        gooPhase++;

        switch (gooPhase)
        {
            case 1:
                dialogueManager.StartDialogue(gooPhase1Dialogue);
                break;
            case 2:
                dialogueManager.StartDialogue(gooPhase2Dialogue);
                break;
            case 3:
                dialogueManager.StartDialogue(gooPhase3Dialogue);
                break;
        }
    }

    public void OnGooDialogueFinished()
    {
        freezeManager.Unfreeze();
        bgEffects.StartSpawning();

        if (gooPhase >= 3)
        {
            dialogueManager.StartDialogue(finalCutsceneDialogue);
        }
    }
}