using Features.Player.Handler;
using Features.Sector.Event;

namespace Features.Player
{
    public class SectorConnector
    {
        private readonly IRaiseCoinsHandler _raiseCoinsHandler;

        public SectorConnector(IRaiseCoinsHandler raiseCoinsHandler)
        {
            _raiseCoinsHandler = raiseCoinsHandler;
        }

        public void TreasureFind(TreasureFound e)
        {
            _raiseCoinsHandler.Invoke(new RaiseCoinsCommand(100));
        }

        public void CoinFind(CoinFound e)
        {
            _raiseCoinsHandler.Invoke(new RaiseCoinsCommand(e.Count));         
        }
    }
}