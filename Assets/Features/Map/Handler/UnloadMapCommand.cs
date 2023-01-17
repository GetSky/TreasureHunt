namespace Features.Map.Handler
{
    public class UnloadMapCommand
    {
    }

    public interface IUnloadMapHandler
    {
        public void Invoke(UnloadMapCommand command);
    }
}