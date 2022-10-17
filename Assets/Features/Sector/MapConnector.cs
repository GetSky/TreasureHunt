using Features.Map.Event;
using Features.Sector.Handler;

namespace Features.Sector
{
    public class MapConnector
    {
        private readonly IDeactivateSectorsHandler _handler;
        private readonly IRemoveSectorsHandler _removeSectorsHandler;
        private readonly IActivateSectorsHandler _activateSectorsHandler;

        public MapConnector(
            IDeactivateSectorsHandler handler,
            IRemoveSectorsHandler removeSectorsHandler,
            IActivateSectorsHandler activateSectorsHandler)
        {
            _handler = handler;
            _removeSectorsHandler = removeSectorsHandler;
            _activateSectorsHandler = activateSectorsHandler;
        }

        public void GameStatusChange(GameStatusChange status)
        {
            if (status.Active) return;
            _handler.Invoke(new DeactivateSectorsCommand());
        }

        public void ResetMap(ResetMap status)
        {
            _removeSectorsHandler.Invoke(new RemoveSectorsCommand());
        }
    }
}