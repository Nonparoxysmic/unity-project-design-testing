using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentCameraControl : MonoBehaviour
{
    [SerializeField] GameObject theCamera;
    
    void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
            theCamera.SetActive(true);
        }
        else
        {
            Destroy(theCamera);
        }
        Destroy(gameObject);
    }
}
