using Features.Camera.View;
using UnityEngine;

namespace Core
{
    public class PlayerControllerService : IInputCameraControl
    {
        private Vector3 _startPosition;

        public Vector3 MousePosition()
        {
            var diff = Vector3.zero;
            var mousePosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(1)) _startPosition = mousePosition;
            else if (Input.GetMouseButton(1))
            {
                diff = new Vector3(mousePosition.x - _startPosition.x, mousePosition.y - _startPosition.y);
                _startPosition = mousePosition;
            }

            return diff;
        }

        public bool IsPressOnSector()
        {
            return false;
        }
    }
}