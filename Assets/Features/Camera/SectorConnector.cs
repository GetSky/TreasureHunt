using Features.Camera.Handler;
using Features.Sector.Event;

namespace Features.Camera
{
    public class SectorConnector
    {
        private readonly ILookAtHandler _handler;

        public SectorConnector(ILookAtHandler handler)
        {
            _handler = handler;
        }
        public void FoundTreasure(TreasureFound status)
        {
            _handler.Invoke(new LookAtCommand(status.X, status.Y, status.Z));
        }
    }
}