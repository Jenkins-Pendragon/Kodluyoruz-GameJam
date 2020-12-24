using UnityEngine.SceneManagement;
using UnityEngine;

public class InitManager : MonoBehaviour
{    void Start()
    {
        //Init Game Here
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        Destroy(gameObject);
    }
}
