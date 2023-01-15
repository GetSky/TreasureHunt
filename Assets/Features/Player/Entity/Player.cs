using System;

namespace Features.Player.Entity
{
    public class Player
    {
        public string Id { get; }
        public int Coins { get; private set; }
        public Action<int> OnCoinsUpdate = delegate { };

        public Player(string id, int coins)
        {
            Id = id;
            Coins = coins;
        }

        public int RaiseCoins(int count)
        {
            Coins += count;
            OnCoinsUpdate(Coins);
            return Coins;
        }
    }
}