namespace Features.Player.Handler
{
    public class RaiseCoinsCommand
    {
    }

    public interface IRaiseCoinsHandler
    {
        public void Invoke(RaiseCoinsCommand command);
    }
}