namespace Features.Sector.Domain.Events
{
    public class CoinDiscovered : IDomainEvent
    {
        public int Grade { get; }
        public float X { get; }
        public float Y { get; }

        public CoinDiscovered(float x, float y, int grade)
        {
            X = x;
            Y = y;
            Grade = grade;
        }
    }
}