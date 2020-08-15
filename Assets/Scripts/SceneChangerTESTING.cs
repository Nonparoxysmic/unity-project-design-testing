using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTESTING : MonoBehaviour
{
    public SceneAsset startupScene;
    public SceneAsset titleScreenScene;
    public SceneAsset mainMenuScene;

    public float timeBetweenScenes;

    private float timeLeft;
    private SceneAsset nextScene;

    void Start()
    {
        timeLeft = timeBetweenScenes;
        nextScene = titleScreenScene;
    }

    void Update()
    {
        if (nextScene == titleScreenScene)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadScene(nextScene.name, LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(startupScene.name);
                timeLeft = timeBetweenScenes;
                nextScene = mainMenuScene;
            }
        }
        else if (nextScene == mainMenuScene)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadScene(nextScene.name, LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(titleScreenScene.name);
                nextScene = null;
            }
        }
    }
}
