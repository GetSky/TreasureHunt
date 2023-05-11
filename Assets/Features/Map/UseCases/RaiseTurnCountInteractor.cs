using Core;
using Features.Map.Adapters;
using Features.Map.Commands;
using Features.Map.Entity;

namespace Features.Map.UseCases
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