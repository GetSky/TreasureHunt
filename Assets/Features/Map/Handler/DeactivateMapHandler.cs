using Core;
using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class DeactivateMapInteractor : IInteractor<DeactivateMapCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public DeactivateMapInteractor(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Execute(DeactivateMapCommand command)
        {
            var map = _repository.FindCurrent();
            map.Deactivate();
            _context.Save(map);
        }
    }
}