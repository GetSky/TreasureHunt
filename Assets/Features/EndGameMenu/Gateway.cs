using Core;
using Features.EndGameMenu.UseCases;

namespace Features.EndGameMenu
{
    public class Gateway
    {
        private readonly IInteractor<ActivateCommand> _activateCase;
        private readonly IInteractor<DeactivateCommand> _deactivateCase;

        public Gateway(IInteractor<ActivateCommand> activateCase, IInteractor<DeactivateCommand> deactivateCase)
        {
            _activateCase = activateCase;
            _deactivateCase = deactivateCase;
        }

        public void Show()
        {
            _activateCase.Execute(new ActivateCommand());
        }
        
        
        public void Hide()
        {
            _deactivateCase.Execute(new DeactivateCommand());
        }
    }
}