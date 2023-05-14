using Features.Sector.Domain;

namespace Features.Sector.UseCases.RemoveSectors
{
    public class RemoveSectorsInteractor : IInteractor<RemoveSectorsCommand>
    {
        private readonly ISectorRepository _repository;

        public RemoveSectorsInteractor(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(RemoveSectorsCommand command)
        {
            foreach (var sector in _repository.FindAll()) sector.Destroy();
            _repository.Clear();
        }
    }
}