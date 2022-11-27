namespace Features.Camera.Handler
{
    public class LookAtCommand
    {
        public float X { get; }
        public float Y { get; }
        public bool Immediately { get; }

        public LookAtCommand(float x, float y, bool immediately)
        {
            X = x;
            Y = y;
            Immediately = immediately;
        }
    }

    public interface ILookAtHandler
    {
        public void Invoke(LookAtCommand command);
    }
}