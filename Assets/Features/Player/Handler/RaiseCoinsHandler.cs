using Features.Player.Repository;

namespace Features.Player.Handler
{
    public class RaiseCoinsHandler : IRaiseCoinsHandler
    {
        private readonly IPlayerRepository _repository;
        private readonly IPlayerContext _context;

        public RaiseCoinsHandler(IPlayerRepository repository, IPlayerContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Invoke(RaiseCoinsCommand command)
        {
            var entity = _repository.FindCurrent();
            entity.RaiseCoins(100);
            _context.Save(entity);
        }
    }
}