namespace Features.Camera.Adapters
{
    public class CameraPresenter : ICameraPresenter
    {
        public event ICameraPresenter.OnLookedAtHandler OnLookedAt;

        public void LookAt(float x, float z, bool isImmediately) => OnLookedAt?.Invoke(x, z, isImmediately);
    }
}