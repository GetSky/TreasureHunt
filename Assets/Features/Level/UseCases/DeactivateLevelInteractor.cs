using Core;
using Features.Level.Commands;
using Features.Level.Domain;

namespace Features.Level.UseCases
{
    public class DeactivateLevelInteractor : IInteractor<DeactivateLevelCommand>
    {
        private readonly ILevelRepository _repository;
        private readonly ILevelContext _context;

        public DeactivateLevelInteractor(ILevelRepository repository, ILevelContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Execute(DeactivateLevelCommand command)
        {
            var level = _repository.FindCurrent();
            level.Deactivate();
            _context.Save(level);
        }
    }
}