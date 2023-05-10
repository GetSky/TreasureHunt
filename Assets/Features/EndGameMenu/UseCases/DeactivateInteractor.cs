using Core;
using Features.EndGameMenu.Adapters;
using Features.EndGameMenu.Commands;

namespace Features.EndGameMenu.UseCases
{
    public class DeactivateInteractor : IInteractor<DeactivateCommand>
    {
        private readonly IEndGamePresenter _presenter;

        public DeactivateInteractor(IEndGamePresenter presenter)
        {
            _presenter = presenter;
        }

        public void Execute(DeactivateCommand _)
        {
            _presenter.ChangeActiveStatus(false);
        }
    }
}