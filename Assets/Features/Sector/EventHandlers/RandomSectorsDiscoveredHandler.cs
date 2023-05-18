using Features.Sector.Domain;
using Features.Sector.Domain.Effects.Events;
using Features.Sector.UseCases;
using Features.Sector.UseCases.OpenSector;
using Zenject;

namespace Features.Sector.EventHandlers
{
    public class RandomSectorsDiscoveredHandler
    {
        private readonly ISectorRepository _repository;
        private readonly IInteractor<OpenSectorCommand> _interactor;
        private readonly SignalBus _bus;

        public RandomSectorsDiscoveredHandler(
            ISectorRepository repository,
            IInteractor<OpenSectorCommand> interactor,
            SignalBus bus
        )
        {
            _repository = repository;
            _interactor = interactor;
            _bus = bus;
        }

        public void Handle(RandomSectorsDiscovered domainEvent)
        {
            var openSector = _repository.FindByXZ(domainEvent.X, domainEvent.Z);
            if (openSector is null) return;

            var treasure = _repository.FindTreasure();
            if (treasure is null) return;

            var events = openSector.RandomOpenFrom(_repository.FindAll(), treasure);
            foreach (var domain in events) _bus.Fire((object)domain);
        }
    }
}