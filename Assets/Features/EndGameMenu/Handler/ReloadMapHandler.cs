using Core;
using Features.Map.Handler;

namespace Features.EndGameMenu.Handler
{
    public class ReloadMapHandler : IHandler<ReloadMapCommand>
    {
        private readonly IHandler<DeactivateCommand> _deactivateHandler;
        private readonly ILoadMapHandler _mapHandler;
        private readonly IUnloadMapHandler _unloadMapHandler;

        public ReloadMapHandler(
            IHandler<DeactivateCommand> deactivateHandler,
            ILoadMapHandler loadMapHandler,
            IUnloadMapHandler unloadMapHandler
        )
        {
            _deactivateHandler = deactivateHandler;
            _mapHandler = loadMapHandler;
            _unloadMapHandler = unloadMapHandler;
        }

        public void Invoke(ReloadMapCommand command)
        {
            _deactivateHandler.Invoke(new DeactivateCommand());
            _unloadMapHandler.Invoke(new UnloadMapCommand());
            _mapHandler.Invoke(new LoadMapCommand());
        }
    }
}