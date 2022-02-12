using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDialogue : MonoBehaviour
{
    DialogueInstance conversation;
    public static bool hasPlayed = false;
    void Start()
    {
        if (hasPlayed)
            return;

        conversation = GetComponent<DialogueInstance>();
        conversation.Interact();
        hasPlayed = true;
    }
}
