using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [HideInInspector] public string CurrentScene { get; private set; }

    private void Start()
    {
        CurrentScene = null;
        if (SceneManager.sceneCount > 2)
        {
            Debug.LogError(gameObject.name + ": Too many scenes loaded.");
        }
        else
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name != gameObject.scene.name)
                {
                    CurrentScene = SceneManager.GetSceneAt(i).name;
                }
            }
        }
    }

    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene, LoadSceneMode.Additive);
        if (CurrentScene != null)
        {
            SceneManager.UnloadSceneAsync(CurrentScene);
        }
        CurrentScene = newScene;
    }
}
