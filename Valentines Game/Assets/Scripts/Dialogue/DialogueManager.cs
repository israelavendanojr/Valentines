using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    VerticalTweenUI tween;
    [SerializeField] TextMeshProUGUI dialougeText;
    public Queue<DialogueLine> sentences = new Queue<DialogueLine>();
    DialogueLine currentSentence;
    private bool inDialouge = false;

    private bool isTyping = false;
    public bool InDialogue { get => inDialouge; }
    public bool IsTyping { get => isTyping; }

    [SerializeField] GameEvent StopMovementEvent, StartMovementEvent;

    void Awake()
    {
        tween = GetComponent<VerticalTweenUI>();
    }

    void Update()
    {

    }
    public void StartDialogue(Conversation conversation)
    {
        tween.Enter();
        inDialouge = true;
        sentences.Clear();
        StopMovementEvent.Raise();

        for (int i = 0; i < conversation.dialogue.Length; i++)
        {
            sentences.Enqueue(conversation.dialogue[i]);
        }

        DisplayNextLine();
    }
    public void DisplayNextLine()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            currentSentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(CO_DisplayLine(currentSentence));
        }
    }
    public void FinishLine()
    {
        isTyping = false;
        StopAllCoroutines();
        dialougeText.text = currentSentence.speaker.speakerName + ": " + currentSentence.dialogue;
    }
    void EndDialogue()
    {
        inDialouge = false;
        tween.Exit();
        StartMovementEvent.Raise();
    }
    public IEnumerator CO_DisplayLine(DialogueLine line)
    {
        isTyping = true;

        dialougeText.text = line.speaker.speakerName + ": ";
        for (int i = 0; i < line.dialogue.Length; i++)
        {
            dialougeText.text += line.dialogue[i];

            GameObject voiceSfx = GameObject.Find("Audio Event: " + line.speaker.voice.name);
            if (voiceSfx == null)
                line.speaker.voice.Play();

            yield return new WaitForSeconds(line.delay / 10);
        }

        isTyping = false;
    }
}
