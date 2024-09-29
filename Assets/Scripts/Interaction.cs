using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour, NPC
{
    [SerializeField] private DialogueTrigger dialogueTrigger; // Reference to the DialogueTrigger component
    public string dialogueId; // Dialogue ID to pass

    // This method is called when the player interacts with the NPC
    public void Interact(Player1 player)
    {
        if (dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue(dialogueId); // Trigger the dialogue with the specified ID
        }
        else
        {
            Debug.LogError("DialogueTrigger component is not assigned!");
        }
    }
}
