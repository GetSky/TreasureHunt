using Core;
using Features.EndGameMenu.Handler;
using Features.Map.Event;

namespace Features.EndGameMenu
{
    public class MapConnector
    {
        private readonly IHandler<DeactivateCommand> _deactivateHandler;
        private readonly IHandler<ActivateCommand> _activateHandler;

        public MapConnector(IHandler<DeactivateCommand> deactivateHandler, IHandler<ActivateCommand> activateHandler)
        {
            _deactivateHandler = deactivateHandler;
            _activateHandler = activateHandler;
        }

        public void GameStatusChange(GameStatusChanged status)
        {
            if (status.Active)
                _deactivateHandler.Invoke(new DeactivateCommand());
            else
                _activateHandler.Invoke(new ActivateCommand());
        }
    }
}