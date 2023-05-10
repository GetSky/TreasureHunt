using Core;
using Features.EndGameMenu.Commands;
using Features.Map.Event;

namespace Features.EndGameMenu.Adapters
{
    public class MapConnector
    {
        private readonly IInteractor<DeactivateCommand> _deactivateInteractor;
        private readonly IInteractor<ActivateCommand> _activateInteractor;

        public MapConnector(
            IInteractor<DeactivateCommand> deactivateInteractor,
            IInteractor<ActivateCommand> activateInteractor
        )
        {
            _deactivateInteractor = deactivateInteractor;
            _activateInteractor = activateInteractor;
        }

        public void GameStatusChange(GameStatusChanged status)
        {
            if (status.Active)
                _deactivateInteractor.Execute(new DeactivateCommand());
            else
                _activateInteractor.Execute(new ActivateCommand());
        }
    }
}