using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPersistentScene : MonoBehaviour
{
    [SerializeField] SceneAsset persistentScene;
    
    void Start()
    {
        if (persistentScene.name != SceneManager.GetSceneByName(persistentScene.name).name)
        {
            Debug.Log("Scene \"" + gameObject.scene.name + "\" loading persistent scene.");
            SceneManager.LoadScene(persistentScene.name, LoadSceneMode.Additive);
        }
        Destroy(gameObject);
    }
}
