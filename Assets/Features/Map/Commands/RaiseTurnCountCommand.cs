using Core;

namespace Features.Map.Commands
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