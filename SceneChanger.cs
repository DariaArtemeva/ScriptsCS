using UnityEngine; 

public class SceneChanger : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}