namespace Features.Sector.Domain.Events
{
    public class EnergyDiscovered : IDomainEvent
    {
        private int Grade { get; }
        public float X { get; }
        public float Y { get; }

        public EnergyDiscovered(float x, float y, int grade)
        {
            X = x;
            Y = y;
            Grade = grade;
        }
    }
}