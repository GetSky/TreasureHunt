namespace Features.Camera.Adapters
{
    public interface ICameraPresenter
    {
        public delegate void OnLookedAtHandler(float x, float z, bool isImmediately);
        public event OnLookedAtHandler OnLookedAt;

        public void LookAt(float x, float z, bool isImmediately);
    }
}