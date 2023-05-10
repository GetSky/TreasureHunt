using Core;
using Features.EndGameMenu.Adapters;
using Features.EndGameMenu.Commands;

namespace Features.EndGameMenu.UseCases
{
    public class ActivateInteractor : IInteractor<ActivateCommand>
    {
        private readonly IEndGamePresenter _presenter;

        public ActivateInteractor(IEndGamePresenter presenter)
        {
            _presenter = presenter;
        }

        public void Execute(ActivateCommand _)
        {
            _presenter.ChangeActiveStatus(true);
        }
    }
}