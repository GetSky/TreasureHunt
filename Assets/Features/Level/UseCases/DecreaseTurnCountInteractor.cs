using Core;
using Features.Level.Adapters;
using Features.Level.Commands;
using Features.Level.Domain;

namespace Features.Level.UseCases
{
    public class DecreaseTurnCountInteractor : IInteractor<DecreaseTurnCountCommand>
    {
        private readonly ILevelRepository _repository;
        private readonly ILevelContext _context;
        private readonly IEnergyPresenterBoundary _presenter;

        public DecreaseTurnCountInteractor(
            ILevelRepository repository,
            ILevelContext context,
            IEnergyPresenterBoundary presenter
        )
        {
            _repository = repository;
            _context = context;
            _presenter = presenter;
        }

        public void Execute(DecreaseTurnCountCommand command)
        {
            var level = _repository.FindCurrent();
            _presenter.UpdateEnergy(level.DecreaseTurnCount());
            _context.Save(level);
        }
    }
}