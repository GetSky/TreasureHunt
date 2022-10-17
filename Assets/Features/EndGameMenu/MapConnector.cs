using Features.EndGameMenu.Handler;
using Features.Map.Event;

namespace Features.EndGameMenu
{
    public class MapConnector
    {
        private readonly IDeactivateMenuHandler _deactivateHandler;
        private readonly IActivateMenuCommand _activateCommand;

        public MapConnector(IDeactivateMenuHandler deactivateHandler, IActivateMenuCommand activateCommand)
        {
            _deactivateHandler = deactivateHandler;
            _activateCommand = activateCommand;
        }

        public void GameStatusChange(GameStatusChange status)
        {
            if (status.Active)
                _deactivateHandler.Invoke(new DeactivateMenuCommand());
            else
                _activateCommand.Invoke(new ActivateMenuCommand());
        }
    }
}