using Features.Map.Event;
using Features.Sector.Handler;

namespace Features.Sector
{
    public class MapConnector
    {
        private readonly IDeactivateSectorsHandler _handler;

        public MapConnector(IDeactivateSectorsHandler handler)
        {
            _handler = handler;
        }

        public void GameStatusChange(GameStatusChange status)
        {
            if (status.Active) return;
            _handler.Invoke(new DeactivateSectorsCommand());
        }
    }
}