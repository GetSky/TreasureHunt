using System.Collections.Generic;
using Features.Camera.View;

namespace Features.Camera
{
    public class CameraModel
    {
        private readonly List<CameraController> _cameraViews = new List<CameraController>();

        public void AddView(CameraController view)
        {
            _cameraViews.Add(view);
        }

        public void LookAt(float x, float z)
        {
            foreach (var view in _cameraViews) view.LookAt(x, z);
        }
    }
}