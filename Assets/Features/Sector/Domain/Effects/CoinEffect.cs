using Features.Sector.Domain.Events;

namespace Features.Sector.Domain.Effects
{
    class CoinEffect : IEffect
    {
        private readonly int _grade;

        public CoinEffect(int grade)
        {
            _grade = grade;
        }

        public IDomainEvent Call(Sector openSector, Sector treasureSector)
        {
            return new EnergyDiscovered(openSector.Position.X, openSector.Position.Y, _grade);
        }
    }
}