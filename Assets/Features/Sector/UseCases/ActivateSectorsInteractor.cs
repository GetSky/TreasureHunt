using Core;
using Features.Sector.Handler;
using Features.Sector.Repository;

namespace Features.Sector.UseCases
{
    public class ActivateSectorsInteractor : IInteractor<ActivateSectorsCommand>
    {
        private readonly ISectorRepository _repository;

        public ActivateSectorsInteractor(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(ActivateSectorsCommand command)
        {
            foreach (var sector in _repository.FindAll()) sector.Activate();
        }
    }
}