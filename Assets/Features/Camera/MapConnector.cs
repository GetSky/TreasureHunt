using Core;
using Features.Camera.Commands;
using Features.Map.Event;

namespace Features.Camera
{
    public class MapConnector
    {
        private readonly IInteractor<LookAtCommand> _interactor;

        public MapConnector(IInteractor<LookAtCommand> interactor)
        {
            _interactor = interactor;
        }

        public void MapReload(MapLoaded _)
        {
            _interactor.Execute(new LookAtCommand(4.5f, 4f, true));
        }
    }
}