using Features.Sector.Domain.Events;
using Features.Sector.UseCases.HighlightSectorsAtDistance;

namespace Features.Sector.Adapters
{
    public class HintDistanceDiscoveredHandler
    {
        private readonly HighlightSectorsAtDistanceInteractor _interactor;

        public HintDistanceDiscoveredHandler(HighlightSectorsAtDistanceInteractor interactor)
        {
            _interactor = interactor;
        }

        public void Execute(HintDistanceDiscovered domainEvent)
        {
            _interactor.Execute(new HighlightSectorsAtDistanceCommand(domainEvent.OpenSectorId, domainEvent.Distance));
        }
    }
}