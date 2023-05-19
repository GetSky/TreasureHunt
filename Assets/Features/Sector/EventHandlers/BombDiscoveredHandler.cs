using System.Threading.Tasks;
using Features.Sector.Domain;
using Features.Sector.Domain.Effects.Events;
using Zenject;

namespace Features.Sector.EventHandlers
{
    public class BombDiscoveredHandler
    {
        private const int MillisecondsDelayBeforeOpen = 1000;

        private readonly ISectorRepository _repository;
        private readonly SignalBus _bus;

        public BombDiscoveredHandler(ISectorRepository repository, SignalBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public void Handle(BombDiscovered domainEvent)
        {
            var openSector = _repository.FindByXZ(domainEvent.X, domainEvent.Z);
            if (openSector is null) return;

            var treasure = _repository.FindTreasure();
            if (treasure is null) return;

            Launcher(openSector, treasure, domainEvent.EffectState.Value);
        }

        private async void Launcher(Domain.Sector openSector, Domain.Sector treasure, int distance)
        {
            await Task.Delay(MillisecondsDelayBeforeOpen);
            var events = openSector.OpenInRadius(_repository.FindAll(), treasure, distance);
            foreach (var domain in events) _bus.Fire((object)domain);
        }
    }
}