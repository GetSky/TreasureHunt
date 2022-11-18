using Features.Camera.Handler;

namespace Features.Camera
{
    public interface ILookAtHandler
    {
        public void Invoke(LookAtCommand command);
    }
}