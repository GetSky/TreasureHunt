using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class EnergyEffect : IEffect
    {
        private readonly int _grade;

        public EnergyEffect(int grade)
        {
            _grade = grade;
        }

        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            if (openSector.Opened) return null;

            return new EnergyDiscovered(
                openSector.Position.X,
                openSector.Position.Y,
                new EffectState(EffectStateType.Energy, _grade, _grade)
            );
        }
    }
}