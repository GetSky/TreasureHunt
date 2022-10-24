using Features.Sector.Event;

namespace Features.Sector.Card
{
    public enum CardType
    {
        None,
        Treasure,
        Distance
    }

    public interface ICard
    {
        public CardType Type();
        public IDomainEvent Execute(int distance, Sector inSector);
        public int Value();
    }
}