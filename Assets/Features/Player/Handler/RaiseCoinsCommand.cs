namespace Features.Player.Handler
{
    public class RaiseCoinsCommand
    {
        public int Count { get; }

        public RaiseCoinsCommand(int count)
        {
            Count = count;
        }
    }

    public interface IRaiseCoinsHandler
    {
        public void Invoke(RaiseCoinsCommand command);
    }
}