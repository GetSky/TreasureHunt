using Core;
using Features.EndGameMenu.Commands;
using Zenject;

namespace Features.EndGameMenu.Adapters
{
    public class EndGamePresenter : IEndGamePresenter
    {
        private readonly LazyInject<IInteractor<ReloadMapCommand>> _interactor;
        public event IEndGamePresenter.OnChangedStatusHandler OnChangedStatus;

        public EndGamePresenter(LazyInject<IInteractor<ReloadMapCommand>> interactor)
        {
            _interactor = interactor;
        }

        public void ChangeActiveStatus(bool isActive) => OnChangedStatus?.Invoke(isActive);

        public void ReloadMap() => _interactor.Value?.Execute(new ReloadMapCommand());
    }
}