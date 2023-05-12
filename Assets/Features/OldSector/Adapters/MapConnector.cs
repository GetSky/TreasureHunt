using Core;
using Features.Map.Event;
using Features.OldSector.Commands;

namespace Features.OldSector.Adapters
{
    public class MapConnector
    {
        private readonly IInteractor<DeactivateSectorsCommand> _interactor;
        private readonly IInteractor<RemoveSectorsCommand> _removeSectorsInteractor;

        public MapConnector(IInteractor<DeactivateSectorsCommand> interactor, IInteractor<RemoveSectorsCommand> removeSectorsInteractor)
        {
            _interactor = interactor;
            _removeSectorsInteractor = removeSectorsInteractor;
        }

        public void GameStatusChange(GameStatusChanged status)
        {
            if (status.Active) return;
            _interactor.Execute(new DeactivateSectorsCommand());
        }

        public void UnloadMap(MapUnloaded status)
        {
            _removeSectorsInteractor.Execute(new RemoveSectorsCommand());
        }
    }
}