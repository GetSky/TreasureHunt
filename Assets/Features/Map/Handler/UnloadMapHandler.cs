using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class UnloadMapHandler : IUnloadMapHandler
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public UnloadMapHandler(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Invoke(UnloadMapCommand command)
        {
            var map = _repository.FindCurrent();
            map.UnloadMap();
            _context.Save(map);
        }
    }
}