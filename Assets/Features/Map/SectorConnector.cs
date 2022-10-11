using Features.Map.Handler;

namespace Features.Map
{
    public class SectorConnector
    {
        private readonly IDeactivateMapHandler _mapHandler;

        public SectorConnector(IDeactivateMapHandler mapHandler)
        {
            _mapHandler = mapHandler;
        }

        public void TreasureFind() => _mapHandler.Invoke(new DeactivateMapCommand());
    }
}