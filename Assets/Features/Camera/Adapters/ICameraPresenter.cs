namespace Features.Camera.Adapters
{
    public interface ICameraPresenter
    {
        public delegate void LookedAtHandler(float x, float z, bool isImmediately);

        public event LookedAtHandler OnLookedAt;

        public void LookAt(float x, float z, bool isImmediately);
        public (float x, float z) GetCurrentPosition();
    }
}