using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInstance : MonoBehaviour, IInteractable, ICancel
{
    [SerializeField] Conversation conversation;
    DialogueManager dialogueManager;

    void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    void Start()
    {

    }
    public void Interact()
    {
        if(!dialogueManager.InDialogue)
            dialogueManager.StartDialogue(conversation);
        else if(!dialogueManager.IsTyping)
            dialogueManager.DisplayNextLine();
    }
    public void Cancel()
    {
        if (dialogueManager.InDialogue)
            dialogueManager.FinishLine();
    }
}
