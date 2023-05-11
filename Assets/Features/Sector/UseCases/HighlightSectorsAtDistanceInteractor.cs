using Core;
using Features.Sector.Commands;
using Features.Sector.Handler;
using Features.Sector.Repository;

namespace Features.Sector.UseCases
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
            var sector = _repository.FindById(command.Id);
            foreach (var sec in _repository.FindAll()) sec.HighlightInRadius(sector, command.Distance);
        }
    }
}