using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class LoadScreen : MonoBehaviour
    {
        private string destinyScene;
        [SerializeField] private Image image;

        private float actualProgress = 0f;

        void Start()
        {
            SetDestinyScene();
            StartCoroutine(CargarEscenaAsincrona());
        }

        private void SetDestinyScene()
        {
            destinyScene = FlowManager.Instance.sceneLoad;
        }

        IEnumerator CargarEscenaAsincrona()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(destinyScene);

            //Evito que la escena se cargue muy rápido.
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)//Si no está cargada
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);

                // Interpola suavemente el progreso actual hacia el progreso real
                actualProgress = Mathf.Lerp(actualProgress, progress, Time.deltaTime * 5f);

                ActualizarBarraCarga(actualProgress);

                if (actualProgress >= 0.99f)
                {
                    asyncOperation.allowSceneActivation = true; // Activamos la escena cuando el progreso esta completo
                }

                yield return null;
            }

            System.GC.Collect();
        }

        void ActualizarBarraCarga(float progreso)
        {
            image.fillAmount = progreso;
        }
    }
}
