using Features.Player.Entity;

namespace Features.Player
{
    public class Factory
    {
        public Entity.Player Create(string id, int coins)
        {
            return new Entity.Player(id, new CoinCounter(coins));
        }
    }
}