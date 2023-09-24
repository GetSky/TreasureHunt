namespace Features.Camera.Adapters
{
    public class CameraPresenter
    {
        private float _x;
        private float _z;

        public delegate void LookedAtHandler(float x, float z, bool isImmediately);
        public event LookedAtHandler OnLookedAt;

        public void LookAt(float x, float z, bool isImmediately)
        {
            _x = x;
            _z = z;
            OnLookedAt?.Invoke(x, z, isImmediately);
        }

        public (float x, float z) GetCurrentPosition()
        {
            return (_x, _z);
        }
    }
}