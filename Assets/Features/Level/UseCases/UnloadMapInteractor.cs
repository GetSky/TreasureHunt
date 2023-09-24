using Core;
using Features.Level.Commands;
using Features.Level.Entity;

namespace Features.Level.UseCases
{
    public class UnloadMapInteractor : IInteractor<UnloadMapCommand>
    {
        private readonly ILevelRepository _repository;
        private readonly ILevelContext _context;

        public UnloadMapInteractor(ILevelRepository repository, ILevelContext context)
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