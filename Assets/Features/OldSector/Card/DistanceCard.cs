using Features.OldSector.Commands;
using Features.OldSector.Event;

namespace Features.OldSector.Card
{
    public class DistanceCard : ICard
    {
        private const int NullValue = -1;
        private const int MaxDistanceToView = 6;
        private int _distanceToTreasure;

        public int Value() => _distanceToTreasure <= MaxDistanceToView ? _distanceToTreasure : NullValue;

        public IDomainEvent Execute(int value, OldSector.Entities.Sector sector)
        {
            _distanceToTreasure = value;
            return Value() > 0 ? new HighlightSectorsAtDistanceCommand(sector.Id, Value()) : null;
        }
    }
}