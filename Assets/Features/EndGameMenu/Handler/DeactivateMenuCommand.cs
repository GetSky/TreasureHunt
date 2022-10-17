namespace Features.EndGameMenu.Handler
{
    public class DeactivateMenuCommand
    {
    }
    
    public interface IDeactivateMenuHandler
    {
        public void Invoke(DeactivateMenuCommand command);
    }
}