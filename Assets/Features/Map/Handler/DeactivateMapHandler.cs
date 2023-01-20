using Core;
using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class DeactivateMapHandler : IHandler<DeactivateMapCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public DeactivateMapHandler(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Invoke(DeactivateMapCommand command)
        {
            var map = _repository.FindCurrent();
            map.Deactivate();
            _context.Save(map);
        }
    }
}