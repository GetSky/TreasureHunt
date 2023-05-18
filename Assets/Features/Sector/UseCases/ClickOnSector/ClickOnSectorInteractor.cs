using Features.Sector.Domain;
using Zenject;

namespace Features.Sector.UseCases.ClickOnSector
{
    public class ClickOnSectorInteractor : IInteractor<ClickOnSectorCommand>
    {
        private readonly ISectorRepository _repository;
        private readonly SignalBus _bus;

        public ClickOnSectorInteractor(ISectorRepository repository, SignalBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public void Execute(ClickOnSectorCommand command)
        {
            var sector = _repository.FindByXZ(command.X, command.Z);
            var domainEvent = sector?.Click();
            if (domainEvent is null) return;
            _bus.Fire((object)sector.Click());
        }
    }
}