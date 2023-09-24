using Core;
using Features.Level.Commands;

namespace Features.Level
{
    public class Gateway
    {
        private readonly IInteractor<LoadLevelCommand> _loadMapInteractor;
        private readonly IInteractor<UnloadLevelCommand> _unloadMapInteractor;

        public Gateway(IInteractor<LoadLevelCommand> loadMapInteractor, IInteractor<UnloadLevelCommand> unloadMapInteractor)
        {
            _loadMapInteractor = loadMapInteractor;
            _unloadMapInteractor = unloadMapInteractor;
        }

        public void Reload()
        {
            _unloadMapInteractor.Execute(new UnloadLevelCommand());
            _loadMapInteractor.Execute(new LoadLevelCommand());
        }
    }
}