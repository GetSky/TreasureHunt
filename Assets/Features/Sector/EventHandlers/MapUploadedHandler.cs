using Features.Map.Event;
using Features.Sector.UseCases;
using Features.Sector.UseCases.RemoveSectors;

namespace Features.Sector.EventHandlers
{
    public class MapUploadedHandler
    {
        private readonly IInteractor<RemoveSectorsCommand> _interactor;

        public MapUploadedHandler(IInteractor<RemoveSectorsCommand> interactor)
        {
            _interactor = interactor;
        }

        public void Execute(MapUnloaded _)
        {
            _interactor.Execute(new RemoveSectorsCommand());
        }
    }
}