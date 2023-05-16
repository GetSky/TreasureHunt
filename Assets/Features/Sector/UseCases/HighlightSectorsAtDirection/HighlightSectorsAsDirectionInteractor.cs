using Features.Sector.Domain;

namespace Features.Sector.UseCases.HighlightSectorsAtDirection
{
    public class HighlightSectorsAsDirectionInteractor : IInteractor<HighlightSectorsAtDirectionCommand>
    {
        private readonly ISectorRepository _repository;

        public HighlightSectorsAsDirectionInteractor(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(HighlightSectorsAtDirectionCommand command)
        {
            var openSector = _repository.FindById(command.Id);
            foreach (var sector in _repository.FindAll())
            {
                sector.HighlightInDirection(openSector, command.Angle);
            }
        }
    }
}