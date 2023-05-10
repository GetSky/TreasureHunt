using Core;
using Features.Player.Handler;
using Features.Sector.Event;

namespace Features.Player
{
    public class SectorConnector
    {
        private readonly IInteractor<RaiseCoinsCommand> _raiseCoinsInteractor;

        public SectorConnector(IInteractor<RaiseCoinsCommand> raiseCoinsInteractor)
        {
            _raiseCoinsInteractor = raiseCoinsInteractor;
        }

        public void TreasureFind(TreasureFound e)
        {
            _raiseCoinsInteractor.Execute(new RaiseCoinsCommand(100));
        }

        public void CoinFind(CoinFound e)
        {
            _raiseCoinsInteractor.Execute(new RaiseCoinsCommand(e.Count));         
        }
    }
}