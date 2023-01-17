using Features.Player.Handler;

namespace Features.Player
{
    public class SectorConnector
    {
        private readonly IRaiseCoinsHandler _raiseCoinsHandler;

        public SectorConnector(IRaiseCoinsHandler raiseCoinsHandler)
        {
            _raiseCoinsHandler = raiseCoinsHandler;
        }

        public void TreasureFind()
        {
            _raiseCoinsHandler.Invoke(new RaiseCoinsCommand());
        }
    }
}