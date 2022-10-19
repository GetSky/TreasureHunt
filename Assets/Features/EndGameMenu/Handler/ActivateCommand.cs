namespace Features.EndGameMenu.Handler
{
    public class ActivateCommand
    {
    }

    public interface IActivateCommand
    {
        public void Invoke(ActivateCommand command);
    }
}