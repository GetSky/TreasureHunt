using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.Domain.Effects
{
    public class CoinEffect : IEffect
    {
        private readonly int _grade;

        public CoinEffect(int grade)
        {
            _grade = grade;
        }

        public IEventDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            if (openSector.Opened) return null;

            return new CoinDiscovered(
                openSector.Position.X,
                openSector.Position.Y,
                new EffectState(EffectStateType.Coin, _grade, _grade)
            );
        }
    }
}