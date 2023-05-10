using Core;
using Features.Map.Handler;
using Features.Sector.Event;

namespace Features.Map
{
    public class SectorConnector
    {
        private readonly IInteractor<DeactivateMapCommand> _deactivateInteractor;
        private readonly IInteractor<DecreaseTurnCountCommand> _turnCountInteractor;
        private readonly IInteractor<RaiseTurnCountCommand> _raiseTurnCountInteractor;

        public SectorConnector(
            IInteractor<DeactivateMapCommand> deactivateInteractor,
            IInteractor<DecreaseTurnCountCommand> turnCountInteractor,
            IInteractor<RaiseTurnCountCommand> raiseTurnCountInteractor
        )
        {
            _deactivateInteractor = deactivateInteractor;
            _turnCountInteractor = turnCountInteractor;
            _raiseTurnCountInteractor = raiseTurnCountInteractor;
        }

        public void TreasureFind() => _deactivateInteractor.Execute(new DeactivateMapCommand());
        public void SectorOpen() => _turnCountInteractor.Execute(new DecreaseTurnCountCommand());

        public void EnergyFound(EnergyFound e) => _raiseTurnCountInteractor.Execute(new RaiseTurnCountCommand(e.Count));
    }
}