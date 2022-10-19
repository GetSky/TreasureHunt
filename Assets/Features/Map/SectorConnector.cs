using Features.Map.Handler;

namespace Features.Map
{
    public class SectorConnector
    {
        private readonly IDeactivateMapHandler _deactivateHandler;

        public SectorConnector(IDeactivateMapHandler deactivateHandler)
        {
            _deactivateHandler = deactivateHandler;
        }

        public void TreasureFind() => _deactivateHandler.Invoke(new DeactivateMapCommand());
    }
}