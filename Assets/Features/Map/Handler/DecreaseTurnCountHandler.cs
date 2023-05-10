using Core;
using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class DecreaseTurnCountInteractor : IInteractor<DecreaseTurnCountCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public DecreaseTurnCountInteractor(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Execute(DecreaseTurnCountCommand command)
        {
            var map = _repository.FindCurrent();
            map.DecreaseTurnCount();
            _context.Save(map);
        }
    }
}