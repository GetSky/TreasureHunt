using Features.Sector.Event;

namespace Features.Sector.Card
{
    public class EnergyCard : ICard
    {
        private readonly int _count;

        public EnergyCard(int count)
        {
            _count = count;
        }

        public int Value() => _count;

        public IDomainEvent Execute(int _, Sector sector) => new EnergyFound(_count);
    }
}