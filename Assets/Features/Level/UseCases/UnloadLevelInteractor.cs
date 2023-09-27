using Core;
using Features.Level.Commands;
using Features.Level.Domain;

namespace Features.Level.UseCases
{
    public class UnloadLevelInteractor : IInteractor<UnloadLevelCommand>
    {
        private readonly ILevelRepository _repository;
        private readonly ILevelContext _context;

        public UnloadLevelInteractor(ILevelRepository repository, ILevelContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Execute(UnloadLevelCommand command)
        {
            var level = _repository.FindCurrent();
            level.UnloadLevel();
            _context.Save(level);
        }
    }
}