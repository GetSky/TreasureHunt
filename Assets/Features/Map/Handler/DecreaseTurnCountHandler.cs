using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class DecreaseTurnCountHandler : IDecreaseTurnCountHandler
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public DecreaseTurnCountHandler(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Invoke(DecreaseTurnCountCommand command)
        {
            var map = _repository.FindCurrent();
            map.DecreaseTurnCount();
            _context.Save(map);
        }
    }
}