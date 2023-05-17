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
            if (sector is not null) _bus.Fire((object)sector.Click());
        }
    }
}