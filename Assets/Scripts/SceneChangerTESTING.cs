using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTESTING : MonoBehaviour
{
    public string titleScreenName;
    public string mainMenuName;
    public float defaultTimeLeft;

    private float timeLeft;
    private string nextScene;

    void Start()
    {
        timeLeft = defaultTimeLeft;
        nextScene = titleScreenName;
    }

    void Update()
    {
        if (nextScene == titleScreenName)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
                timeLeft = defaultTimeLeft;
                nextScene = mainMenuName;
            }
        }
        else if (nextScene == mainMenuName)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(titleScreenName);
                nextScene = "None";
            }
        }
    }
}
