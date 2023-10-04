using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class FlowManager : MonoBehaviour
    {

        #region Singleton
        
        public static FlowManager Instance;
        
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


        private void GoToInit()
        {
            LoadScene("Init");
        }

        private void GoToMenu()
        {
            LoadScene("Menu");
        }

        private void GoToInGame()
        {
            LoadScene("InGame");
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
