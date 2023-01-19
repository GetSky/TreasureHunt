namespace Features.Sector.Event
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