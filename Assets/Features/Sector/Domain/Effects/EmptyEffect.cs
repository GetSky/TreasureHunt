using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class EmptyEffect : IEffect
    {
        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            return new EmptyDiscovered(
                openSector.Position.X,
                openSector.Position.Y,
                new EffectState(EffectStateType.Empty, 0, 0)
            );
        }
    }
}