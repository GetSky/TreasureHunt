namespace Features.OldSector.Event
{
    public class EnergyFound : IDomainEvent
    {
        public int Count { get; }

        public EnergyFound(int count)
        {
            Count = count;
        }
    }
}