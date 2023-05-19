using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class BombEffect : IEffect
    {
        private readonly int _grade;

        public BombEffect(int grade)
        {
            _grade = grade;
        }
        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            if (openSector.Opened) return null;

            return new BombDiscovered(
                openSector.Position.X,
                openSector.Position.Y,
                new EffectState(EffectStateType.Bomb, _grade, _grade)
            );
        }
    }
}