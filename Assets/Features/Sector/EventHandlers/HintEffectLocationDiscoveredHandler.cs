using Features.Sector.Domain;
using Features.Sector.Domain.Effects.Events;

namespace Features.Sector.EventHandlers
{
    public class HintEffectLocationDiscoveredHandler
    {
        private readonly ISectorRepository _repository;

        public HintEffectLocationDiscoveredHandler(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Handle(HintEffectLocationDiscovered domainEvent)
        {
            var openSector = _repository.FindByXZ(domainEvent.X, domainEvent.Z);
            if (openSector is null) return;

            var sectors = _repository.FindAll();
            if (sectors is null) return;

            openSector.HighlightSectorWithEffects(sectors, domainEvent.EffectState.Value);
        }
    }
}