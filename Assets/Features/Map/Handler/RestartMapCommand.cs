namespace Features.Map.Handler
{
    public class RestartMapCommand
    {
    }

    public interface IRestartMapHandler
    {
        public void Invoke(RestartMapCommand command);
    }
}