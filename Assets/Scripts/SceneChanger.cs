using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string CurrentScene { get; private set; }
    public SceneAsset startupScene;

    private void Start()
    {
        CurrentScene = startupScene.name;
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene, LoadSceneMode.Additive);
        try
        {
            SceneManager.UnloadSceneAsync(CurrentScene);
        }
        catch
        {
            Debug.Log("Scene to unload is invalid: " + CurrentScene);
        }
        
        CurrentScene = newScene;
    }
}
