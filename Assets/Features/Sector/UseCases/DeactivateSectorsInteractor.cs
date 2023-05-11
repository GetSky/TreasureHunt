using Core;
using Features.Sector.Commands;
using Features.Sector.Entities;
using Features.Sector.Handler;
using Features.Sector.Repository;

namespace Features.Sector.UseCases
{
    public class DeactivateSectorsInteractor : IInteractor<DeactivateSectorsCommand>
    {
        private readonly ISectorRepository _repository;

        public DeactivateSectorsInteractor(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeactivateSectorsCommand command)
        {
            foreach (var sector in _repository.FindAll()) sector.Deactivate();
        }
    }
}