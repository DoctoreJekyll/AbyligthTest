using UnityEngine;

namespace CameraBehaviour
{
    public class CameraRenderTexture : MonoBehaviour
    {
        public RenderTexture renderTexture;
        public Material invertColorMaterial;

        private Camera renderCamera;

        private void Awake()
        {
            renderCamera = GetComponent<Camera>();
            renderCamera.targetTexture = renderTexture;
            renderCamera.enabled = false;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(source, destination, invertColorMaterial);
        }
    }
}
