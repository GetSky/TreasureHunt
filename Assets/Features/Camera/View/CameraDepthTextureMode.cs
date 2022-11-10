using UnityEngine;

namespace Features.Camera.View
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraDepthTextureMode : MonoBehaviour
    {
        [SerializeField] private DepthTextureMode _depthTextureMode;

        private void OnValidate()
        {
            SetCameraDepthTextureMode();
        }

        private void Awake()
        {
            SetCameraDepthTextureMode();
        }

        private void SetCameraDepthTextureMode()
        {
            GetComponent<UnityEngine.Camera>().depthTextureMode = _depthTextureMode;
        }
    }
}