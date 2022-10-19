using Features.EndGameMenu.Handler;
using Features.Map.Event;

namespace Features.EndGameMenu
{
    public class MapConnector
    {
        private readonly IDeactivateHandler _deactivateHandler;
        private readonly IActivateCommand _activateCommand;

        public MapConnector(IDeactivateHandler deactivateHandler, IActivateCommand activateCommand)
        {
            _deactivateHandler = deactivateHandler;
            _activateCommand = activateCommand;
        }

        public void GameStatusChange(GameStatusChanged status)
        {
            if (status.Active)
                _deactivateHandler.Invoke(new DeactivateCommand());
            else
                _activateCommand.Invoke(new ActivateCommand());
        }
    }
}