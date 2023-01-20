using Core;
using Features.Map.Handler;

namespace Features.EndGameMenu.Handler
{
    public class ReloadMapHandler : IHandler<ReloadMapCommand>
    {
        private readonly IHandler<DeactivateCommand> _deactivateHandler;
        private readonly IHandler<LoadMapCommand> _mapHandler;
        private readonly IHandler<UnloadMapCommand> _unloadMapHandler;

        public ReloadMapHandler(
            IHandler<DeactivateCommand> deactivateHandler,
            IHandler<LoadMapCommand> loadMapHandler,
            IHandler<UnloadMapCommand> unloadMapHandler
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