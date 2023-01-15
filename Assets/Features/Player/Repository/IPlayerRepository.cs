namespace Features.Player.Repository
{
    public interface IPlayerRepository
    {
        public Entity.Player FindCurrent();
    }
}