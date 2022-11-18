using Features.Camera.Handler;
using Features.Sector.Event;

namespace Features.Camera
{
    public class MapConnector
    {
        private readonly ILookAtHandler _handler;

        public MapConnector(ILookAtHandler handler)
        {
            _handler = handler;
        }
        public void FoundTreasure(TreasureFound status)
        {
            _handler.Invoke(new LookAtCommand(status.X, status.Y, status.Z));
        }
    }
}