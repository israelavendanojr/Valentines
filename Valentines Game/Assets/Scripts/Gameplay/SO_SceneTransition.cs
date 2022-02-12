using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scene Transition/Scene Transition")]
public class SO_SceneTransition : ScriptableObject
{
    public SO_VectorValue spawnPos;
    public Vector2 exitPos;
    public string targetScene;
}
