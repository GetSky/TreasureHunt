namespace Features.Camera.Handler
{
    public class LookAtCommand
    {
        public float X { get; }
        public float Y { get; }

        public LookAtCommand(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public interface ILookAtHandler
    {
        public void Invoke(LookAtCommand command);
    }
}