using Core;

namespace Features.Player.Commands
{
    public class RaiseCoinsCommand : ICommand
    {
        public int Count { get; }

        public RaiseCoinsCommand(int count)
        {
            Count = count;
        }
    }
}