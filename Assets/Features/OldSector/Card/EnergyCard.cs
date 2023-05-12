using Features.OldSector.Event;

namespace Features.OldSector.Card
{
    public class EnergyCard : ICard
    {
        private readonly int _count;

        public EnergyCard(int count)
        {
            _count = count;
        }

        public int Value() => _count;

        public IDomainEvent Execute(int _, OldSector.Entities.Sector sector) => new EnergyFound(_count);
    }
}