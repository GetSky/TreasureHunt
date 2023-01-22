using Core;
using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class RaiseTurnCountHandler : IHandler<RaiseTurnCountCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public RaiseTurnCountHandler(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }
        
        public void Invoke(RaiseTurnCountCommand command)
        {
            var map = _repository.FindCurrent();
            map.RaiseTurnCount(command);
            _context.Save(map);
        }
    }
}