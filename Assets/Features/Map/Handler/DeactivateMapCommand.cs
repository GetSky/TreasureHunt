namespace Features.Map.Handler
{
    public class DeactivateMapCommand
    {
    }

    public interface IDeactivateMapHandler
    {
        public void Invoke(DeactivateMapCommand command);
    }
}