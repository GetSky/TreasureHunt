namespace Features.EndGameMenu.Handler
{
    public class ReloadMapCommand
    {
    }

    public interface IReloadMapHandler
    {
        public void Invoke(ReloadMapCommand command);
    }
}