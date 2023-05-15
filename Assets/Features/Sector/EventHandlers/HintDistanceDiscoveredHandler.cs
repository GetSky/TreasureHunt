using Features.Sector.Domain.Effects.Events;
using Features.Sector.Domain.Events;
using Features.Sector.UseCases;
using Features.Sector.UseCases.HighlightSectorsAtDistance;

namespace Features.Sector.EventHandlers
{
    public class HintDistanceDiscoveredHandler
    {
        private readonly IInteractor<HighlightSectorsAtDistanceCommand> _interactor;

        public HintDistanceDiscoveredHandler(IInteractor<HighlightSectorsAtDistanceCommand> interactor)
        {
            _interactor = interactor;
        }

        public void Execute(HintDistanceDiscovered domainEvent)
        {
            _interactor.Execute(
                new HighlightSectorsAtDistanceCommand(domainEvent.OpenSectorId, domainEvent.EffectState.Value)
            );
        }
    }
} 