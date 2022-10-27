using Features.Map.Event;
using Features.Sector.Handler;

namespace Features.Sector
{
    public class MapConnector
    {
        private readonly IDeactivateSectorsHandler _handler;
        private readonly IRemoveSectorsHandler _removeSectorsHandler;

        public MapConnector(IDeactivateSectorsHandler handler, IRemoveSectorsHandler removeSectorsHandler)
        {
            _handler = handler;
            _removeSectorsHandler = removeSectorsHandler;
        }

        public void GameStatusChange(GameStatusChanged status)
        {
            if (status.Active) return;
            _handler.Invoke(new DeactivateSectorsCommand());
        }

        public void ResetMap(MapReloaded status)
        {
            _removeSectorsHandler.Invoke(new RemoveSectorsCommand());
        }
    }
}