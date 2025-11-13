using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI Elements")]
    public TextMeshProUGUI npcText;
    public TextMeshProUGUI heroText;
    public TextMeshProUGUI villainText;

    [Header("Dialogue Bubble Objects")]
    public GameObject npcBubbleObject;
    public GameObject heroBubbleObject;
    public GameObject villainBubbleObject;

    private Queue<DialogueLine> lines;
    private bool isDialogueActive = false;

    void Start()
    {
        lines = new Queue<DialogueLine>();

        // Hide all bubbles at the start
        if (npcBubbleObject) npcBubbleObject.SetActive(false);
        if (heroBubbleObject) heroBubbleObject.SetActive(false);
        if (villainBubbleObject) villainBubbleObject.SetActive(false);
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log($"🗨️ Starting conversation: {dialogue.conversationName}");
        Debug.Log("🔍 Checking DialogueManager references...");

        if (dialogue == null)
        {
            Debug.LogError("❌ Dialogue asset is NULL!");
            return;
        }
        if (dialogue.lines == null)
        {
            Debug.LogError("❌ dialogue.lines is NULL!");
            return;
        }

        Debug.Log($"✅ Dialogue has {dialogue.lines.Length} lines");

        // Pause game during dialogue
        Time.timeScale = 0f;
        isDialogueActive = true;

        // Prepare lines
        lines.Clear();
        foreach (DialogueLine line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (lines == null || lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        // Hide all previous bubbles
        HideAllBubbles();

        // Display based on speaker
        switch (currentLine.speaker)
        {
            case DialogueLine.Speaker.NPC:
                npcText.text = currentLine.text;
                npcBubbleObject.SetActive(true);
                break;
            case DialogueLine.Speaker.Hero:
                heroText.text = currentLine.text;
                heroBubbleObject.SetActive(true);
                break;
            case DialogueLine.Speaker.Villain:
                villainText.text = currentLine.text;
                villainBubbleObject.SetActive(true);
                break;
        }
    }

    private void HideAllBubbles()
    {
        if (npcBubbleObject) npcBubbleObject.SetActive(false);
        if (heroBubbleObject) heroBubbleObject.SetActive(false);
        if (villainBubbleObject) villainBubbleObject.SetActive(false);
    }

    public void EndDialogue()
    {
        Debug.Log("✅ End of conversation");

        isDialogueActive = false;

        // Resume game
        Time.timeScale = 1f;

        FindAnyObjectByType<Scene2Manager>()?.OnGooDialogueFinished();
        HideAllBubbles();
        FindFirstObjectByType<Scene2Manager>()?.OnGooDialogueFinished();
    }
}