using Core;
using Features.Level.Adapters;
using Features.Level.Commands;
using Features.Level.Entity;

namespace Features.Level.UseCases
{
    public class RaiseTurnCountInteractor : IInteractor<RaiseTurnCountCommand>
    {
        private readonly IMapRepository _repository;
        private readonly IMapContext _context;
        private readonly IEnergyPresenterBoundary _presenter;

        public RaiseTurnCountInteractor(IMapRepository repository, IMapContext context, IEnergyPresenterBoundary presenter)
        {
            _repository = repository;
            _context = context;
            _presenter = presenter;
        }
        
        public void Execute(RaiseTurnCountCommand command)
        {
            var map = _repository.FindCurrent();
            _presenter.UpdateEnergy(map.RaiseTurnCount(command));
            _context.Save(map);
        }
    }
}