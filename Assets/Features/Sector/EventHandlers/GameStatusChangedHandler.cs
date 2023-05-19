using Features.Map.Event;
using Features.Sector.UseCases;
using Features.Sector.UseCases.ActivateSectors;
using Features.Sector.UseCases.DeactivateSectors;

namespace Features.Sector.EventHandlers
{
    public class GameStatusChangedHandler
    {
        private readonly IInteractor<ActivateSectorsCommand> _activateInteractor;
        private readonly IInteractor<DeactivateSectorsCommand> _deactivateInteractor;

        public GameStatusChangedHandler(
            IInteractor<ActivateSectorsCommand> activateInteractor,
            IInteractor<DeactivateSectorsCommand> deactivateInteractor
        )
        {
            _activateInteractor = activateInteractor;
            _deactivateInteractor = deactivateInteractor;
        }

        public void Handle(GameStatusChanged domainEvent)
        {
            if (domainEvent.Active) _activateInteractor.Execute(new ActivateSectorsCommand());
            else _deactivateInteractor.Execute(new DeactivateSectorsCommand());
        }
    }
}