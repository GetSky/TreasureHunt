using Features.OldSector.Event;

namespace Features.OldSector.Card
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
        public IDomainEvent Execute(int distance, OldSector.Entities.Sector inSector);
        public int Value();
    }
}