using Core;
using Features.Map.Commands;
using Features.Sector.Domain.Events;

namespace Features.Map.Adapters
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

        public void EnergyFound(EnergyDiscovered e) => _raiseTurnCountInteractor.Execute(new RaiseTurnCountCommand(e.Grade));
    }
}