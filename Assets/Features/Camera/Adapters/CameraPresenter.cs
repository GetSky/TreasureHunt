namespace Features.Camera.Adapters
{
    public class CameraPresenter : ICameraPresenter
    {
        public event ICameraPresenter.LookedAtHandler OnLookedAt;

        public void LookAt(float x, float z, bool isImmediately) => OnLookedAt?.Invoke(x, z, isImmediately);
    }
}