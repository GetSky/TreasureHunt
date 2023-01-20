using Core;
using Features.Map.Handler;

namespace Features.Map
{
    public class SectorConnector
    {
        private readonly IHandler<DeactivateMapCommand> _deactivateHandler;
        private readonly IHandler<DecreaseTurnCountCommand> _turnCountHandler;

        public SectorConnector(IHandler<DeactivateMapCommand> deactivateHandler, IHandler<DecreaseTurnCountCommand> turnCountHandler)
        {
            _deactivateHandler = deactivateHandler;
            _turnCountHandler = turnCountHandler;
        }

        public void TreasureFind() => _deactivateHandler.Invoke(new DeactivateMapCommand());
        public void SectorOpen() => _turnCountHandler.Invoke(new DecreaseTurnCountCommand());
    }
}