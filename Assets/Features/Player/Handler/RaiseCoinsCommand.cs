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
}