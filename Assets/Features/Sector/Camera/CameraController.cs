using UnityEngine;

namespace Features.Sector.Camera
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _startPosition;
        private UnityEngine.Camera _camera;

        private void Start()
        {
            _camera = GetComponent<UnityEngine.Camera>();
        }

        private void Update()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;

            if (Input.GetMouseButtonDown(1)) _startPosition = _camera.ScreenToWorldPoint(mousePosition);
            else if (Input.GetMouseButton(1))
            {
                var position = transform.position;
                transform.position = new Vector3(
                    position.x - _camera.ScreenToWorldPoint(mousePosition).x - _startPosition.x,
                    position.y,
                    position.z - _camera.ScreenToWorldPoint(mousePosition).z - _startPosition.z
                );
            }
        }
    }
}