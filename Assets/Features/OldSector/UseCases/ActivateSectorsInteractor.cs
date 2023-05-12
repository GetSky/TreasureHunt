using Core;
using Features.OldSector.Commands;
using Features.OldSector.Entities;

namespace Features.OldSector.UseCases
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