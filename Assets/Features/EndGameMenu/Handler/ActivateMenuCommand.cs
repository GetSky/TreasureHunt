namespace Features.EndGameMenu.Handler
{
    public class ActivateMenuCommand
    {
    }

    public interface IActivateMenuCommand
    {
        public void Invoke(ActivateMenuCommand command);
    }
}