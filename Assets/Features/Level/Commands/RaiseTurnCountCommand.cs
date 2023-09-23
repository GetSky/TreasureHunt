using Core;

namespace Features.Level.Commands
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