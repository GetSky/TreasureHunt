namespace Features.OldSector.Event
{
    public class CoinFound : IDomainEvent
    {
        public int Count { get; }

        public CoinFound(int count)
        {
            Count = count;
        }
    }
}