using Core;
using Features.Player.Repository;

namespace Features.Player.Handler
{
    public class RaiseCoinsInteractor : IInteractor<RaiseCoinsCommand>
    {
        private readonly IPlayerRepository _repository;
        private readonly IPlayerContext _context;

        public RaiseCoinsInteractor(IPlayerRepository repository, IPlayerContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Execute(RaiseCoinsCommand command)
        {
            var entity = _repository.FindCurrent();
            entity.RaiseCoins(command.Count);
            _context.Save(entity);
        }
    }
}