using Features.OldSector.Event;

namespace Features.OldSector.Card
{
    public class TreasureCard : ICard
    {
        private const int NullValue = 0;

        public int Value() => NullValue;

        public IDomainEvent Execute(int _, OldSector.Entities.Sector sector) => new TreasureFound(sector.Position.X, sector.Position.Y);
    }
}