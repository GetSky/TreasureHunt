using Core;
using Features.Player.Handler;
using Features.Sector.Event;

namespace Features.Player
{
    public class SectorConnector
    {
        private readonly IHandler<RaiseCoinsCommand> _raiseCoinsHandler;

        public SectorConnector(IHandler<RaiseCoinsCommand> raiseCoinsHandler)
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