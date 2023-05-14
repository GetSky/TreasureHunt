using Features.Sector.Domain;

namespace Features.Sector.UseCases.DeactivateSectors
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