using Features.Camera.View;
using Features.Sector.View;
using UnityEngine;

namespace Core
{
    public class PlayerControllerService : IInputCameraControl, IInputSectorControl
    {
        private Vector3 _startPosition;
        private bool _cameraMoved = false;

        public Vector3 MousePosition()
        {
            var diff = Vector3.zero;
            var mousePosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(0)) _startPosition = mousePosition;
            else if (Input.GetMouseButton(0))
            {
                diff = new Vector3(mousePosition.x - _startPosition.x, mousePosition.y - _startPosition.y);
                if (diff != Vector3.zero) _cameraMoved = true;
                _startPosition = mousePosition;
            }

            return diff;
        }

        public bool IsPressOnSector()
        {
            var pressed = !_cameraMoved;
            _cameraMoved = false;
            return pressed;
        }
    }
}