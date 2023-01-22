namespace Features.Map.Handler
{
    public class RaiseTurnCountCommand
    {
        public int Count { get; }

        public RaiseTurnCountCommand(int count)
        {
            Count = count;
        }
    }
}