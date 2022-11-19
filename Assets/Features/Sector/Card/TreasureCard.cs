using Features.Sector.Event;

namespace Features.Sector.Card
{
    public class TreasureCard : ICard
    {
        private const int NullValue = 0;

        public int Value() => NullValue;

        public IDomainEvent Execute(int _, Sector sector) => new TreasureFound(sector.Position.X, sector.Position.Y);
    }
}