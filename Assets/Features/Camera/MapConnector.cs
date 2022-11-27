using Features.Camera.Handler;
using Features.Map.Event;

namespace Features.Camera
{
    public class MapConnector
    {
        private readonly ILookAtHandler _handler;

        public MapConnector(ILookAtHandler handler)
        {
            _handler = handler;
        }

        public void MapReload(MapReloaded _)
        {
            _handler.Invoke(new LookAtCommand(4.5f, 4f, true));
        }
    }
}