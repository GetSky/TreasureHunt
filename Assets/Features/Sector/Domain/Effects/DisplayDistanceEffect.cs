using Features.Sector.Domain.Events;

namespace Features.Sector.Domain.Effects
{
    public class DisplayDistanceEffect : IEffect
    {
        private readonly int _grade;

        public DisplayDistanceEffect(int grade)
        {
            _grade = grade;
        }

        public int Value() => _grade + 1;

        public IDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            var distance = openSector.MeasureDistanceTo(treasureSector);
            return new HintDistanceDiscovered(
                openSector.Id,
                distance > _grade + 1 ? 0 : distance
            );
        }
    }
}