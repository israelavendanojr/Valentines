using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    public DialogueLine[] dialogue;
    [SerializeField]public UnityAction u;
}
[System.Serializable]
public struct DialogueLine
{
    public Speaker speaker;
    [TextArea(2, 5)] public string dialogue;
    public float delay;
}
