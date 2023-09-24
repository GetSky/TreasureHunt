using Core;
using Features.Level.Commands;
using Features.Level.Entity;

namespace Features.Level.UseCases
{
    public class DeactivateMapInteractor : IInteractor<DeactivateMapCommand>
    {
        private readonly ILevelRepository _repository;
        private readonly ILevelContext _context;

        public DeactivateMapInteractor(ILevelRepository repository, ILevelContext context)
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