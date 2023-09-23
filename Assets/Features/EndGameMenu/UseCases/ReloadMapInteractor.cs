using Core;

namespace Features.EndGameMenu.UseCases
{
    public class ReloadMapInteractor : IInteractor<ReloadMapCommand>
    {
        private readonly IInteractor<DeactivateCommand> _deactivateInteractor;
        private readonly Level.Gateway _map;

        public ReloadMapInteractor(IInteractor<DeactivateCommand> deactivateInteractor, Level.Gateway map)
        {
            _deactivateInteractor = deactivateInteractor;
            _map = map;
        }

        public void Execute(ReloadMapCommand command)
        {
            _deactivateInteractor.Execute(new DeactivateCommand());
            _map.Reload();
        }
    }
}