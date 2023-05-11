using Core;
using Features.Player.Commands;
using Zenject;

namespace Features.Player.Adapters
{
    public class CoinPresenter : ICoinPresenter, ICoinPresenterBoundary
    {
        public event ICoinPresenter.OnUpdatedCoinsHandler OnUpdatedCoins;
        private readonly LazyInject<IInteractor<RequestCountCoinsCommand>> _getCoinsInteractor;
        private int _count;

        public CoinPresenter(LazyInject<IInteractor<RequestCountCoinsCommand>> getCoinsInteractor)
        {
            _getCoinsInteractor = getCoinsInteractor;
        }

        public int CurrentCounts()
        {
            _getCoinsInteractor.Value.Execute(new RequestCountCoinsCommand());
            return _count;
        }

        public void UpdateCoin(int count)
        {
            _count = count;
            OnUpdatedCoins?.Invoke(_count);
        }

        public void SetCoin(int count) => _count = count;
    }
}