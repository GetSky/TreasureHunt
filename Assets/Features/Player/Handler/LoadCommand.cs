namespace Features.Player.Handler
{
    public class LoadCommand
    {
    }

    public interface ILoadCommand
    {
        public void Invoke(LoadCommand command);
    }
}