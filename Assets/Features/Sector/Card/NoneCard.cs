namespace Features.Sector.Card
{
    public class NoneCard : ICard
    {
        private const int NullValue = -1;

        public CardType Type() => CardType.None;

        public int Value() => NullValue;

        public void UpdateDistanceToTreasure(int value) => _ = value;
    }
}