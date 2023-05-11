using Core;
using Features.Player.Adapters;
using Features.Player.Commands;
using Features.Player.Entity;

namespace Features.Player.UseCases
{
    public class RaiseCoinsInteractor : IInteractor<RaiseCoinsCommand>
    {
        private readonly IPlayerRepository _repository;
        private readonly IPlayerContext _context;
        private readonly ICoinPresenterBoundary _presenter;

        public RaiseCoinsInteractor(
            IPlayerRepository repository,
            IPlayerContext context,
            ICoinPresenterBoundary presenter
        )
        {
            _repository = repository;
            _context = context;
            _presenter = presenter;
        }

        public void Execute(RaiseCoinsCommand command)
        {
            var entity = _repository.FindCurrent();
            _presenter.UpdateCoin(entity.RaiseCoins(command.Count));
            _context.Save(entity);
        }
    }
}