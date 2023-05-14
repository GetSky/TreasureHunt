using Features.Sector.Domain.Events;

namespace Features.Sector.Domain.Effects
{
    class TreasureEffect : IEffect
    {
        private readonly int _grade;

        public TreasureEffect(int grade)
        {
            _grade = grade;
        }

        public IDomainEvent Call(Sector openSector, Sector _)
        {
            return new TreasureDiscovered(openSector.Position.X, openSector.Position.Y, _grade);
        }
    }
}