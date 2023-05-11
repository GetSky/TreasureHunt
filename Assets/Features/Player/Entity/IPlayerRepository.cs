namespace Features.Player.Entity
{
    public interface IPlayerRepository
    {
        public Player FindCurrent();
    }
}