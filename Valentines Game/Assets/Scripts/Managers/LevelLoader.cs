using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    VerticalTweenUI transition;
    float waitTime = 1f;
    bool isLoading;
    void Awake()
    {
        instance = this;
        transition = GameObject.Find("Transition").GetComponent<VerticalTweenUI>();
    }
    private void Start()
    {
        transition.Exit();
    }
    void Update()
    {
    }
    public void ReloadScene()
    {
        StartCoroutine(LoadSceneIndex(SceneManager.GetActiveScene().buildIndex));
    }
    public void NextSceen()
    {
        StartCoroutine(LoadSceneIndex(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void PreviousScene()
    {
        StartCoroutine(LoadSceneIndex(SceneManager.GetActiveScene().buildIndex - 1));
    }
    IEnumerator LoadSceneIndex(int index)
    {
        if (!isLoading)
        {
            transition.Enter();
            isLoading = true;
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(index);
            isLoading = false;
        }
    }
    public void LoadSceneName(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }
    IEnumerator LoadScene(string levelName)
    {
        if (!isLoading)
        {
            transition.Enter();
            isLoading = true;
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(levelName);
            isLoading = true;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
