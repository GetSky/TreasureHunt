namespace Features.Player.Entity
{
    public class Player
    {
        public string Id { get; }
        private readonly CoinCounter _coins;

        public Player(string id, CoinCounter coins)
        {
            Id = id;
            _coins = coins;
        }

        public int RaiseCoins(int count)
        {
            _coins.Raise(count);
            return _coins.Count;
        }

        public int CountCoins()
        {
            return _coins.Count;
        }
    }
}