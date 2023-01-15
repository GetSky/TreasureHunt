namespace Features.Player.Repository
{
    public class MemoryPlayerRepository : IPlayerContext, IPlayerRepository
    {
        public void Save(Entity.Player player)
        {
            throw new System.NotImplementedException();
        }

        public Entity.Player FindCurrent()
        {
            throw new System.NotImplementedException();
        }
    }
}