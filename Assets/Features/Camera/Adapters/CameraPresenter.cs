namespace Features.Camera.Adapters
{
    public class CameraPresenter : ICameraPresenter
    {
        private float _x;
        private float _z;

        public event ICameraPresenter.LookedAtHandler OnLookedAt;

        public void LookAt(float x, float z, bool isImmediately)
        {
            _x = x;
            _z = z;
            OnLookedAt?.Invoke(x, z, isImmediately);
        }

        public (float, float) GetCurrentPosition()
        {
            return (_x, _z);
        }
    }
}