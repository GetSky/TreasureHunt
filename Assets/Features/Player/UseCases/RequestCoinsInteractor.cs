using Core;
using Features.Player.Adapters;
using Features.Player.Commands;
using Features.Player.Entity;

namespace Features.Player.UseCases
{
    public class RequestCoinsInteractor : IInteractor<RequestCountCoinsCommand>
    {
        private readonly IPlayerRepository _repository;
        private readonly ICoinPresenterBoundary _presenter;

        public RequestCoinsInteractor(IPlayerRepository repository, ICoinPresenterBoundary presenter)
        {
            _repository = repository;
            _presenter = presenter;
        }

        public void Execute(RequestCountCoinsCommand _)
        {
            var entity = _repository.FindCurrent();
            _presenter.SetCoin(entity.CountCoins());
        }
    }
}