using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class TreasureEffect : IEffect
    {
        private readonly int _grade;

        public TreasureEffect(int grade)
        {
            _grade = grade;
        }

        public IEventDomainEvent Call(Sector openSector, Sector _)
        {
            return new TreasureDiscovered(
                openSector.Position.X,
                openSector.Position.Y,
                new EffectState(EffectStateType.Treasure, _grade, _grade)
            );
        }
    }
}