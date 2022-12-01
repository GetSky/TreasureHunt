namespace Features.Map.Handler
{
    public class LoadMapCommand
    {
    }

    public interface ILoadMapHandler
    {
        public void Invoke(LoadMapCommand command);
    }
}