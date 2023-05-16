using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class DisplayDistanceEffect : IEffect
    {
        private readonly int _grade;

        public DisplayDistanceEffect(int grade)
        {
            _grade = grade;
        }

        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            var distance = openSector.MeasureDistanceTo(treasureSector);
            var state = distance > _grade + 1
                ? new EffectState(EffectStateType.TooFar, _grade, 0)
                : new EffectState(EffectStateType.Distance, _grade, distance);

            return new HintDistanceDiscovered(
                openSector.Id,
                state
            );
        }
    }
}