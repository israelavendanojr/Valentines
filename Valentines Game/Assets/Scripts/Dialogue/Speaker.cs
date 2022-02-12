using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Speaker")]
public class Speaker : ScriptableObject
{
    public string speakerName;
    public Sprite portrait;
    public SimpleAudioEvent voice;

}
