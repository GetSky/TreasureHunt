using Core;
using Features.Level.Adapters;
using Features.Level.Commands;
using Features.Level.Domain;

namespace Features.Level.UseCases
{
    public class RaiseTurnCountInteractor : IInteractor<RaiseTurnCountCommand>
    {
        private readonly ILevelRepository _repository;
        private readonly ILevelContext _context;
        private readonly IEnergyPresenterBoundary _presenter;

        public RaiseTurnCountInteractor(
            ILevelRepository repository,
            ILevelContext context,
            IEnergyPresenterBoundary presenter
        )
        {
            _repository = repository;
            _context = context;
            _presenter = presenter;
        }

        public void Execute(RaiseTurnCountCommand command)
        {
            var level = _repository.FindCurrent();
            _presenter.UpdateEnergy(level.RaiseTurnCount(command));
            _context.Save(level);
        }
    }
}