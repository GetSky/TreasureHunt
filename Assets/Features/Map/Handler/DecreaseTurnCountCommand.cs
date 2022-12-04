namespace Features.Map.Handler
{
    public class DecreaseTurnCountCommand
    {
    }

    public interface IDecreaseTurnCountHandler
    {
        public void Invoke(DecreaseTurnCountCommand command);
    }
}