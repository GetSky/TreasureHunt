namespace Features.Player.Repository
{
    public interface IPlayerContext
    {
        public void Save(Entity.Player player);
    }
}