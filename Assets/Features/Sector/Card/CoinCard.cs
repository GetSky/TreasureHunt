using Features.Sector.Event;

namespace Features.Sector.Card
{
    public class CoinCard : ICard
    {
        private readonly int _count;

        public CoinCard(int count)
        {
            _count = count;
        }

        public int Value() => _count;

        public IDomainEvent Execute(int _, Sector sector) => new CoinFound(10);
    }
}