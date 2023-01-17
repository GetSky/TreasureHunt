namespace Features.Player
{
    public class Factory
    {
        public Entity.Player Create(string id, int coins)
        {
            var entity = new Entity.Player(id, coins);
            return entity;
        }
    }
}