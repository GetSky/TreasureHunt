namespace Features.Sector.Domain.Events
{
    public class TreasureDiscovered : IDomainEvent
    {
        private int Grade { get; }
        public float X { get; }
        public float Y { get; }

        public TreasureDiscovered(float x, float y, int grade)
        {
            X = x;
            Y = y;
            Grade = grade;
        }
    }
}