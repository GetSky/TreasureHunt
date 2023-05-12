using Features.OldSector.Event;

namespace Features.OldSector.Card
{
    public class CoinCard : ICard
    {
        private readonly int _count;

        public CoinCard(int count)
        {
            _count = count;
        }

        public int Value() => _count;

        public IDomainEvent Execute(int _, OldSector.Entities.Sector sector) => new CoinFound(_count);
    }
}