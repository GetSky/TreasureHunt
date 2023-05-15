using Core;
using Features.Player.Commands;
using Features.Sector.Domain.Effects.Events;
using Features.Sector.Domain.Events;

namespace Features.Player.Adapters
{
    public class SectorConnector
    {
        private readonly IInteractor<RaiseCoinsCommand> _raiseCoinsInteractor;

        public SectorConnector(IInteractor<RaiseCoinsCommand> raiseCoinsInteractor)
        {
            _raiseCoinsInteractor = raiseCoinsInteractor;
        }

        public void TreasureFind(TreasureDiscovered e)
        {
            _raiseCoinsInteractor.Execute(new RaiseCoinsCommand(100));
        }

        public void CoinFind(CoinDiscovered e)
        {
            _raiseCoinsInteractor.Execute(new RaiseCoinsCommand(e.EffectState.Grade));         
        }
    }
}