using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour, IInteractable
{
    [SerializeField] SO_SceneTransition sceneTransition;
    [SerializeField] SimpleAudioEvent transitionSfx;

    public void Interact()
    {
        LoadTargetScene();
    }

    void LoadTargetScene()
    {
        sceneTransition.spawnPos.position = sceneTransition.exitPos;
        transitionSfx.Play();
        LevelLoader.instance.LoadSceneName(sceneTransition.targetScene);
    }
}
