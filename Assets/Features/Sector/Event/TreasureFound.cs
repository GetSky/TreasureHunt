namespace Features.Sector.Event
{
    public class TreasureFound : IDomainEvent
    {
        public float X { get; }
        public float Y { get; }

        public TreasureFound(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}