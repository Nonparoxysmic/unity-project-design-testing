using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTESTING : MonoBehaviour
{
    public string startupName;
    public string persistentName;
    public string titleScreenName;
    public float defaultTimeLeft;

    private float timeLeft;
    private string nextScene;

    void Start()
    {
        timeLeft = defaultTimeLeft;
        nextScene = persistentName;
    }

    void Update()
    {
        if (nextScene == persistentName)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
                timeLeft = defaultTimeLeft;
                nextScene = titleScreenName;
            }
        }
        else if (nextScene == titleScreenName)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                SceneManager.UnloadSceneAsync(startupName);
                SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
                nextScene = "None";
            }
        }
    }
}
