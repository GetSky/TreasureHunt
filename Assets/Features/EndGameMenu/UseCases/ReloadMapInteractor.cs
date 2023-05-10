using Core;
using Features.EndGameMenu.Commands;
using Features.Map.Handler;

namespace Features.EndGameMenu.UseCases
{
    public class ReloadMapInteractor : IInteractor<ReloadMapCommand>
    {
        private readonly IInteractor<DeactivateCommand> _deactivateInteractor;
        private readonly IInteractor<LoadMapCommand> _mapInteractor;
        private readonly IInteractor<UnloadMapCommand> _unloadMapInteractor;

        public ReloadMapInteractor(
            IInteractor<DeactivateCommand> deactivateInteractor,
            IInteractor<LoadMapCommand> loadMapInteractor,
            IInteractor<UnloadMapCommand> unloadMapInteractor
        )
        {
            _deactivateInteractor = deactivateInteractor;
            _mapInteractor = loadMapInteractor;
            _unloadMapInteractor = unloadMapInteractor;
        }

        public void Execute(ReloadMapCommand command)
        {
            _deactivateInteractor.Execute(new DeactivateCommand());
            _unloadMapInteractor.Execute(new UnloadMapCommand());
            _mapInteractor.Execute(new LoadMapCommand());
        }
    }
}