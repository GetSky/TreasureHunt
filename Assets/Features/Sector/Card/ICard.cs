using Features.Sector.Event;

namespace Features.Sector.Card
{
    public enum CardType
    {
        None,
        Treasure,
        Coin,
        Distance,
        Energy,
    }

    public interface ICard
    {
        public IDomainEvent Execute(int distance, Sector inSector);
        public int Value();
    }
}