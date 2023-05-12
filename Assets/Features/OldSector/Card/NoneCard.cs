using Features.OldSector.Event;

namespace Features.OldSector.Card
{
    public class NoneCard : ICard
    {
        private const int NullValue = -1;

        public int Value() => NullValue;

        public IDomainEvent Execute(int value, OldSector.Entities.Sector sector) => null;
    }
}