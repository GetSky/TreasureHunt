using Core;
using Features.Map.Handler;
using Features.Sector.Event;

namespace Features.Map
{
    public class SectorConnector
    {
        private readonly IHandler<DeactivateMapCommand> _deactivateHandler;
        private readonly IHandler<DecreaseTurnCountCommand> _turnCountHandler;
        private readonly IHandler<RaiseTurnCountCommand> _raiseTurnCountHandler;

        public SectorConnector(
            IHandler<DeactivateMapCommand> deactivateHandler,
            IHandler<DecreaseTurnCountCommand> turnCountHandler,
            IHandler<RaiseTurnCountCommand> raiseTurnCountHandler
        )
        {
            _deactivateHandler = deactivateHandler;
            _turnCountHandler = turnCountHandler;
            _raiseTurnCountHandler = raiseTurnCountHandler;
        }

        public void TreasureFind() => _deactivateHandler.Invoke(new DeactivateMapCommand());
        public void SectorOpen() => _turnCountHandler.Invoke(new DecreaseTurnCountCommand());

        public void EnergyFound(EnergyFound e) => _raiseTurnCountHandler.Invoke(new RaiseTurnCountCommand(e.Count));
    }
}