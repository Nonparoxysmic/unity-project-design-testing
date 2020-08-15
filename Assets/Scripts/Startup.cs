using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    [SerializeField]
    private SceneAsset persistentScene;

    void Start()
    {
        SceneManager.LoadScene(persistentScene.name, LoadSceneMode.Additive);
    }
}
