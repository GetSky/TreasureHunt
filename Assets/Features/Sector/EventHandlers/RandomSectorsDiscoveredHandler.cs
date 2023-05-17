using Features.Sector.Domain.Effects.Events;
using Features.Sector.UseCases;
using Features.Sector.UseCases.HighlightSectorsAtDistance;
using Features.Sector.UseCases.OpenSector;
using UnityEngine;

namespace Features.Sector.EventHandlers
{
    public class RandomSectorsDiscoveredHandler
    {
        private readonly IInteractor<OpenSectorCommand> _interactor;

        public RandomSectorsDiscoveredHandler(IInteractor<OpenSectorCommand> interactor)
        {
            _interactor = interactor;
        }

        public void Handle(RandomSectorsDiscovered domainEvent)
        {
            Debug.Log("Random Boom!");
        }
    }
}