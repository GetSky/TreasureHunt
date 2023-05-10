using Core;
using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class RaiseTurnCountInteractor : IInteractor<RaiseTurnCountCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public RaiseTurnCountInteractor(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }
        
        public void Execute(RaiseTurnCountCommand command)
        {
            var map = _repository.FindCurrent();
            map.RaiseTurnCount(command);
            _context.Save(map);
        }
    }
}