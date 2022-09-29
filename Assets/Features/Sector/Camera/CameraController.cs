using UnityEngine;

namespace Features.Sector.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Range(0.1f, 2.0f)] [SerializeField] private float _speed = 1.0f;
        private Vector3 _startPosition;

        private void Update()
        {
            var mousePosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(1)) _startPosition = mousePosition;
            else if (Input.GetMouseButton(1))
            {
                transform.position = CalculatePosition(mousePosition, transform.position);
                _startPosition = mousePosition;
            }
        }

        private Vector3 CalculatePosition(Vector3 mouse, Vector3 currentPosition)
        {
            return new Vector3(
                currentPosition.x - (mouse.x - _startPosition.x) / (100 / _speed),
                currentPosition.y,
                currentPosition.z - (mouse.y - _startPosition.y) / (100 / _speed)
            );
        }
    }
}