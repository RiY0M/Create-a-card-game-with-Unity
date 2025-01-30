using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    void Update() {}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}