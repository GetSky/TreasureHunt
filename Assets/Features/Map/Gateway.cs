using Core;
using Features.Map.Commands;

namespace Features.Map
{
    public class Gateway
    {
        private readonly IInteractor<LoadMapCommand> _loadMapInteractor;
        private readonly IInteractor<UnloadMapCommand> _unloadMapInteractor;

        public Gateway(IInteractor<LoadMapCommand> loadMapInteractor, IInteractor<UnloadMapCommand> unloadMapInteractor)
        {
            _loadMapInteractor = loadMapInteractor;
            _unloadMapInteractor = unloadMapInteractor;
        }

        public void Reload()
        {
            _unloadMapInteractor.Execute(new UnloadMapCommand());
            _loadMapInteractor.Execute(new LoadMapCommand());
        }
    }
}