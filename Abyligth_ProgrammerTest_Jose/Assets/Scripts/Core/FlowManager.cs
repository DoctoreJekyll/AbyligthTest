using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class FlowManager : MonoBehaviour
    {

        #region Singleton
        
        public static FlowManager Instance;
        
        public string sceneLoad;
        
        private void Awake()
        {
            CreateSingleton();
        }


        private void CreateSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }
        
        #endregion


        public void GoToInit()
        {
            sceneLoad = "Init";
            LoadScene("Init");
        }

        public void GoToMenu()
        {
            sceneLoad = "Menu";
            LoadScene("LoadingScreen");
        }

        public void GoToInGame()
        {
            sceneLoad = "InGame";
            LoadScene("LoadingScreen");
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
