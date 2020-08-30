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
        if (SceneManager.sceneCount == 1)
        {
            nextScene = null;
        }
        else
        {
            nextScene = titleScreenScene;
        }
    }

    void Update()
    {
        if (nextScene == titleScreenScene)
        {
            gameObject.GetComponent<SceneChanger>().ChangeScene(nextScene.name);
            nextScene = mainMenuScene;
        }
        else if (nextScene == mainMenuScene)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                gameObject.GetComponent<SceneChanger>().ChangeScene(nextScene.name);
                nextScene = null;
            }
        }
    }
}
