using Features.Sector.Domain;

namespace Features.Sector.UseCases.HighlightSectorsAtDistance
{
    public class HighlightSectorsAtDistanceInteractor : IInteractor<HighlightSectorsAtDistanceCommand>
    {
        private readonly ISectorRepository _repository;

        public HighlightSectorsAtDistanceInteractor(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(HighlightSectorsAtDistanceCommand command)
        {
            var centerSector = _repository.FindById(command.Id);
            foreach (var sector in _repository.FindAll()) sector.HighlightInRadius(centerSector, command.Distance);
        }
    }
}