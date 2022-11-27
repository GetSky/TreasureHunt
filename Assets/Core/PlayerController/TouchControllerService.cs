﻿using Features.Camera.View;
using Features.Sector.View;
using UnityEngine;

namespace Core.PlayerController
{
    public class TouchControllerService : IInputCameraControl, IInputSectorControl
    {
        private const float SlipTolerance = 4f;

        private Vector3 _startPosition;
        private bool _cameraMoved;

        public Vector3 MousePosition()
        {
            var diff = Vector3.zero;
            if (Input.touchCount == 0) return diff;

            var mousePosition = Input.touches[0].position;
            
            if (Input.touches[0].phase == TouchPhase.Began) _startPosition = mousePosition;
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                diff = new Vector3(mousePosition.x - _startPosition.x, mousePosition.y - _startPosition.y);
                if (_cameraMoved == false && diff.sqrMagnitude < SlipTolerance) diff = Vector3.zero;
                if (diff != Vector3.zero) _cameraMoved = true;
                _startPosition = mousePosition;
            }

            if (Input.touches[0].phase == TouchPhase.Ended) _cameraMoved = false;

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