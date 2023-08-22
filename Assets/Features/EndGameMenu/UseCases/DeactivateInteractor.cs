using Core;
using Features.EndGameMenu.Adapters;

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