using Core;
using Features.OldSector.Event;
using Features.Player.Commands;

namespace Features.Player.Adapters
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