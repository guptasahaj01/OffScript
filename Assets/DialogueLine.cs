using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    // This enum defines our three speakers
    public enum Speaker { Hero, Villain, NPC }
    public Speaker speaker;

    [TextArea(3, 10)]
    public string text;
}