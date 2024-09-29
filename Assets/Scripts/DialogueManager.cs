using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI[] optionTexts; // Array for displaying up to 5 options
    [SerializeField] private float textSpeed = 0.05f;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject optionsPanel;

    private Coroutine typingCoroutine;
    private Queue<string> sentences;
    private DialogueOption[] currentOptions;
    private bool optionsDisplayed;

    private Dialogue currentDialogue;
    private DialogueTrigger currentNpc;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueTrigger npc, string dialogueId)
    {
        dialoguePanel.SetActive(true);
        currentNpc = npc;
        currentDialogue = GetDialogueById(npc.dialogues, dialogueId);

        if (currentDialogue == null)
        {
            Debug.LogError($"Dialogue ID not found: {dialogueId}");
            return;
        }

        sentences.Clear();
        foreach (string sentence in currentDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    private Dialogue GetDialogueById(Dialogue[] dialogues, string dialogueId)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            if (dialogue.id == dialogueId)
                return dialogue;
        }
        return null;
    }

    public void DisplayNextSentence()
    {
        // If options are displayed, don't continue typing sentences
        if (optionsDisplayed)
            return;

        if (!dialogueText.gameObject.activeInHierarchy)
        {
            dialogueText.gameObject.SetActive(true);
        }

        if (sentences.Count == 0)
        {
            // No more sentences, display options instead
            DisplayOptions();
            return;
        }

        string sentence = sentences.Dequeue();

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeLine(sentence));
    }

    void DisplayOptions()
    {
        if (currentDialogue.options != null && currentDialogue.options.Length > 0)
        {
            optionsPanel.gameObject.SetActive(true);
            currentOptions = currentDialogue.options;
            optionsDisplayed = true;

            // Display up to 5 options as text
            for (int i = 0; i < optionTexts.Length; i++)
            {
                if (i < currentOptions.Length)
                {
                    optionTexts[i].text = (i + 1) + ". " + currentOptions[i].optionText; // Display option text
                    optionTexts[i].gameObject.SetActive(true); // Ensure text is active
                }
                else
                {
                    optionTexts[i].gameObject.SetActive(false); // Hide unused options
                }
            }
        }
        else
        {
            // If no options, end the dialogue
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        foreach (var optionText in optionTexts)
        {
            optionText.gameObject.SetActive(false);
        }
        optionsDisplayed = false; // Reset options display flag
        currentNpc = null;  // Reset the current NPC
        currentDialogue = null;  // Reset the current dialogue
        Debug.Log("End of Dialogue");
    }

    void Update()
    {
        // Handle number key input for option selection
        if (optionsDisplayed)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && currentOptions.Length >= 1)
            {
                SelectOption(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && currentOptions.Length >= 2)
            {
                SelectOption(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && currentOptions.Length >= 3)
            {
                SelectOption(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && currentOptions.Length >= 4)
            {
                SelectOption(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && currentOptions.Length >= 5)
            {
                SelectOption(4);
            }
        }
        else if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            DisplayNextSentence();
        }
    }

    void SelectOption(int index)
    {
        optionsPanel.gameObject.SetActive(false);
        // Clear the displayed options
        /*foreach (var optionText in optionTexts)
        {
            optionText.gameObject.SetActive(false);
        }*/

        optionsDisplayed = false;

        // Start the next dialogue based on the selected option
        string nextDialogueId = currentOptions[index].nextDialogueId;
        StartDialogue(currentNpc, nextDialogueId);
    }

    IEnumerator TypeLine(string sentence)
    {
        dialogueText.text = string.Empty;

        foreach (char c in sentence)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
