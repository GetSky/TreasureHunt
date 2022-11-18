namespace Features.Camera.Handler
{
    public class LookAtCommand
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public LookAtCommand(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}