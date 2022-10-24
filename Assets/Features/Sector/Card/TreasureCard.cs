using Features.Sector.Event;

namespace Features.Sector.Card
{
    public class TreasureCard : ICard
    {
        private const int NullValue = 0;

        public CardType Type() => CardType.Treasure;

        public int Value() => NullValue;

        public IDomainEvent Execute(int value, Sector sector) => new TreasureFound();
    }
}