namespace Features.Sector.Domain.Events
{
    public class SectorClicked : IDomainEvent
    {
        public SectorClicked(float x, float z)
        {
            X = x;
            Z = z;
        }

        public float X { get; }

        public float Z { get; }
    }
}