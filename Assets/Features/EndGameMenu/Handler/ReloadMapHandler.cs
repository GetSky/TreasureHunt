using Features.Map.Handler;

namespace Features.EndGameMenu.Handler
{
    public class ReloadMapHandler : IReloadMapHandler
    {
        private readonly IDeactivateHandler _deactivateHandler;
        private readonly ILoadMapHandler _mapHandler;
        private readonly IUnloadMapCommand _unloadMapCommand;

        public ReloadMapHandler(
            IDeactivateHandler deactivateHandler,
            ILoadMapHandler loadMapHandler,
            IUnloadMapCommand unloadMapCommand
        )
        {
            _deactivateHandler = deactivateHandler;
            _mapHandler = loadMapHandler;
            _unloadMapCommand = unloadMapCommand;
        }

        public void Invoke(ReloadMapCommand command)
        {
            _deactivateHandler.Invoke(new DeactivateCommand());
            _unloadMapCommand.Invoke(new UnloadMapCommand());
            _mapHandler.Invoke(new LoadMapCommand());
        }
    }
}