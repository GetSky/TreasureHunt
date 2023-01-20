using Core;
using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class HighlightSectorsAtDistanceHandler : IHandler<HighlightSectorsAtDistanceCommand>
    {
        private readonly ISectorRepository _repository;

        public HighlightSectorsAtDistanceHandler(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Invoke(HighlightSectorsAtDistanceCommand command)
        {
            var sector = _repository.FindById(command.Id);
            foreach (var sec in _repository.FindAll()) sec.HighlightInRadius(sector, command.Distance);
        }
    }
}