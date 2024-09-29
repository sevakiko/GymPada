using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption
{
    public string optionText;
    public string nextDialogueId;
}

[System.Serializable]
public class Dialogue
{
    public string id;
    [TextArea(3, 10)]
    public string[] sentences;
    public DialogueOption[] options;
}
