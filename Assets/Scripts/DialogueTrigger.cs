using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;

    public void TriggerDialogue(string dialogueId)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(this, dialogueId);
    }
}
