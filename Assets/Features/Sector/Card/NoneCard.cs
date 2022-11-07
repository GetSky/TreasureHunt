using Features.Sector.Event;

namespace Features.Sector.Card
{
    public class NoneCard : ICard
    {
        private const int NullValue = -1;

        public int Value() => NullValue;

        public IDomainEvent Execute(int value, Sector sector) => null;
    }
}