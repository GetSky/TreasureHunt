namespace Features.Sector.Card
{
    public class TreasureCard : ICard
    {
        private int _distanceToTreasure;

        public CardType Type() => CardType.Treasure;

        public int Value() => _distanceToTreasure;

        public void UpdateDistanceToTreasure(int value) => _distanceToTreasure = value;
    }
}