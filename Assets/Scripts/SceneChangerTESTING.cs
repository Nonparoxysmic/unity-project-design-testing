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
    private GameObject sceneChanger;

    void Start()
    {
        timeLeft = timeBetweenScenes;
        nextScene = titleScreenScene;
        sceneChanger = GameObject.Find("SceneChanger");
    }

    void Update()
    {
        if (nextScene == titleScreenScene)
        {
            timeLeft = -1;
            if (timeLeft < 0)
            {
                //SceneManager.LoadScene(nextScene.name, LoadSceneMode.Additive);
                //SceneManager.UnloadSceneAsync(startupScene.name);
                sceneChanger.GetComponent<SceneChanger>().ChangeScene(nextScene.name);
                
                timeLeft = timeBetweenScenes;
                nextScene = mainMenuScene;
            }
        }
        else if (nextScene == mainMenuScene)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                //SceneManager.LoadScene(nextScene.name, LoadSceneMode.Additive);
                //SceneManager.UnloadSceneAsync(titleScreenScene.name);
                sceneChanger.GetComponent<SceneChanger>().ChangeScene(nextScene.name);

                nextScene = null;
            }
        }
    }
}
