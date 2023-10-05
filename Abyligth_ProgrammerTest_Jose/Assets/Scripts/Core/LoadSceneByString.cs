using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LoadSceneByString : MonoBehaviour
    {
        public void LoadSceneWith(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
