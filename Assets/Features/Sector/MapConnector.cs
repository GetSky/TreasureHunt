using Core;
using Features.Map.Event;
using Features.Sector.Handler;

namespace Features.Sector
{
    public class MapConnector
    {
        private readonly IHandler<DeactivateSectorsCommand> _handler;
        private readonly IHandler<RemoveSectorsCommand> _removeSectorsHandler;

        public MapConnector(IHandler<DeactivateSectorsCommand> handler, IHandler<RemoveSectorsCommand> removeSectorsHandler)
        {
            _handler = handler;
            _removeSectorsHandler = removeSectorsHandler;
        }

        public void GameStatusChange(GameStatusChanged status)
        {
            if (status.Active) return;
            _handler.Invoke(new DeactivateSectorsCommand());
        }

        public void UnloadMap(MapUnloaded status)
        {
            _removeSectorsHandler.Invoke(new RemoveSectorsCommand());
        }
    }
}