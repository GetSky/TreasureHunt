using Core;
using Features.Map.Commands;
using Features.Map.Entity;

namespace Features.Map.UseCases
{
    public class UnloadMapInteractor : IInteractor<UnloadMapCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;

        public UnloadMapInteractor(IMapRepository repository, IMapContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Execute(UnloadMapCommand command)
        {
            var map = _repository.FindCurrent();
            map.UnloadMap();
            _context.Save(map);
        }
    }
}