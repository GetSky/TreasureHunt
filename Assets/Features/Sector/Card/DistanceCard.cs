namespace Features.Sector.Card
{
    public class DistanceCard : ICard
    {
        private const int NullValue = -1;
        private const int MaxDistanceToView = 6;
        private int _distanceToTreasure;

        public CardType Type() => CardType.Distance;

        public int Value() => _distanceToTreasure <= MaxDistanceToView ? _distanceToTreasure : NullValue;

        public void UpdateDistanceToTreasure(int value) => _distanceToTreasure = value;
    }
}