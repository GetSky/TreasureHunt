using Core;

namespace Features.Map.Handler
{
    public class RaiseTurnCountCommand : ICommand
    {
        public int Count { get; }

        public RaiseTurnCountCommand(int count)
        {
            Count = count;
        }
    }
}