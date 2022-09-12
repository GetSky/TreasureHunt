namespace Features.Sector
{
    public enum CardType
    {
        None,
        Treasure,
        Distance
    }
    public class Card
    {
        public CardType Type { get; }

        public Card(CardType type)
        {
            Type = type;
        }
    }
}