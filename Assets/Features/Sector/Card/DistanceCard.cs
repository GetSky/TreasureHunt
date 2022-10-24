using Features.Sector.Event;
using Features.Sector.Handler;

namespace Features.Sector.Card
{
    public class DistanceCard : ICard
    {
        private const int NullValue = -1;
        private const int MaxDistanceToView = 6;
        private int _distanceToTreasure;

        public CardType Type() => CardType.Distance;

        public int Value() => _distanceToTreasure <= MaxDistanceToView ? _distanceToTreasure : NullValue;

        public IDomainEvent Execute(int value, Sector sector)
        {
            _distanceToTreasure = value;
            return Value() > 0 ? new HighlightSectorsAtDistanceCommand(sector.Id, Value()) : null;
        }
    }
}