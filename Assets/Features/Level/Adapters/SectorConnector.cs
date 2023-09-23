using Core;
using Features.Level.Commands;
using Features.Sector.Domain.Effects.Events;

namespace Features.Level.Adapters
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

        public void DeactivateMap() => _deactivateInteractor.Execute(new DeactivateMapCommand());
        public void TurnCount() => _turnCountInteractor.Execute(new DecreaseTurnCountCommand());

        public void EnergyFound(EnergyDiscovered e) => _raiseTurnCountInteractor.Execute(new RaiseTurnCountCommand(e.EffectState.Grade));
    }
}