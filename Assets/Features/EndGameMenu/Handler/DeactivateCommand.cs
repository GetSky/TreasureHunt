namespace Features.EndGameMenu.Handler
{
    public class DeactivateCommand
    {
    }

    public interface IDeactivateHandler
    {
        public void Invoke(DeactivateCommand command);
    }
}