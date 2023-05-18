using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class DisplayEffectLocationEffect : IEffect
    {
        private readonly int _grade;

        public DisplayEffectLocationEffect(int grade)
        {
            _grade = grade;
        }

        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            return new HintEffectLocationDiscovered(
                openSector.Position.X,
                openSector.Position.Y,
                new EffectState(EffectStateType.CardsLocation, _grade, _grade + 3)
            );
        }
    }
}