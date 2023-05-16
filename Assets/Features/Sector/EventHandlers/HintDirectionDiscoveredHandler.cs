using Features.Sector.Domain.Effects.Events;
using Features.Sector.UseCases;
using Features.Sector.UseCases.HighlightSectorsAtDirection;

namespace Features.Sector.EventHandlers
{
    public class HintDirectionHandler
    {
        private readonly IInteractor<HighlightSectorsAtDirectionCommand> _interactor;

        public HintDirectionHandler(IInteractor<HighlightSectorsAtDirectionCommand> interactor)
        {
            _interactor = interactor;
        }

        public void Execute(HintDirectionDiscovered domainEvent)
        {
            _interactor.Execute(
                new HighlightSectorsAtDirectionCommand(domainEvent.OpenSectorId, domainEvent.EffectState.Value)
            );
        }
    }
} 