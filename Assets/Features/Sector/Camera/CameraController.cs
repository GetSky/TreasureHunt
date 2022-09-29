using UnityEngine;

namespace Features.Sector.Camera
{
    public class CameraController : MonoBehaviour
    {
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
                currentPosition.x - (mouse.x - _startPosition.x) / 100,
                currentPosition.y,
                currentPosition.z - (mouse.y - _startPosition.y) / 100
            );
        }
    }
}