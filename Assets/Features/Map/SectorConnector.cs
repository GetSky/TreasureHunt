using Features.Map.Handler;

namespace Features.Map
{
    public class SectorConnector
    {
        private readonly IDeactivateMapHandler _deactivateHandler;
        private readonly IDecreaseTurnCountHandler _turnCountHandler;

        public SectorConnector(IDeactivateMapHandler deactivateHandler, IDecreaseTurnCountHandler turnCountHandler)
        {
            _deactivateHandler = deactivateHandler;
            _turnCountHandler = turnCountHandler;
        }

        public void TreasureFind() => _deactivateHandler.Invoke(new DeactivateMapCommand());
        public void SectorOpen() => _turnCountHandler.Invoke(new DecreaseTurnCountCommand());
    }
}