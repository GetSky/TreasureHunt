namespace Features.Map.Handler
{
    public class UnloadMapCommand
    {
    }

    public interface IUnloadMapCommand
    {
        public void Invoke(UnloadMapCommand command);
    }
}