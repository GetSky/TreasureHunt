using Features.Sector.Domain;
using Zenject;

namespace Features.Sector.UseCases.OpenSector
{
    public class OpenSectorInteractor : IInteractor<OpenSectorCommand>
    {
        private readonly ISectorRepository _repository;
        private readonly SignalBus _bus;

        public OpenSectorInteractor(ISectorRepository repository, SignalBus bus)
        {
            _repository = repository;
            _bus = bus;
        }

        public void Execute(OpenSectorCommand command)
        {
            var openSector = _repository.FindById(command.Id);
            var sectorWithTreasure = _repository.FindTreasure();
            if (sectorWithTreasure is null || openSector is null) return;

            _bus.Fire((object)openSector.OpenWithTreasureIn(sectorWithTreasure));
        }
    }
}