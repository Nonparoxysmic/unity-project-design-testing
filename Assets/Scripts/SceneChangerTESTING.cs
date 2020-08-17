using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTESTING : MonoBehaviour
{
    public SceneAsset startupScene;
    public SceneAsset titleScreenScene;
    public SceneAsset mainMenuScene;
    public GameObject theCamera;
    public float timeBetweenScenes;

    private float timeLeft;
    private SceneAsset nextScene;
    private GameObject sceneChanger;
    private int numberOfScenes;

    void Start()
    {
        timeLeft = timeBetweenScenes;
        nextScene = titleScreenScene;
        sceneChanger = GameObject.Find("SceneChanger");
        numberOfScenes = SceneManager.sceneCount;
        if (numberOfScenes == 1)
        {
            theCamera.SetActive(true);
            nextScene = null;
        }
    }

    void Update()
    {
        if (nextScene == titleScreenScene)
        {
            //SceneManager.LoadScene(nextScene.name, LoadSceneMode.Additive);
            //SceneManager.UnloadSceneAsync(startupScene.name);
            sceneChanger.GetComponent<SceneChanger>().ChangeScene(nextScene.name);
            nextScene = mainMenuScene;
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
