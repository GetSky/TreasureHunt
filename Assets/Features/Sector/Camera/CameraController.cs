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

            if (Input.GetMouseButtonDown(1)) _startPosition = mousePosition;
            else if (Input.GetMouseButton(1))
            {
                var position = transform.position;
                transform.position = new Vector3(
                    position.x - (mousePosition.x - _startPosition.x) / 100,
                    position.y,
                    position.z - (mousePosition.y - _startPosition.y) / 100
                );

                _startPosition = mousePosition;
            }
        }
    }
}