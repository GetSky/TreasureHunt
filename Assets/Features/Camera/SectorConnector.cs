using Core;
using Features.Camera.Handler;
using Features.Sector.Event;

namespace Features.Camera
{
    public class SectorConnector
    {
        private readonly IHandler<LookAtCommand> _handler;

        public SectorConnector(IHandler<LookAtCommand> handler)
        {
            _handler = handler;
        }

        public void FoundTreasure(TreasureFound status)
        {
            _handler.Invoke(new LookAtCommand(status.X, status.Y, false));
        }
    }
}