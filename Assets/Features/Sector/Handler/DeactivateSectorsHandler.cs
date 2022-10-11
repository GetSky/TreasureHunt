using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class DeactivateSectorsHandler : IDeactivateSectorsHandler
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorFlasher _flasher;

        public DeactivateSectorsHandler(ISectorRepository sectorRepo, ISectorFlasher flasher)
        {
            _sectorRepo = sectorRepo;
            _flasher = flasher;
        }

        public void Invoke(DeactivateSectorsCommand command)
        {
            foreach (var sector in _sectorRepo.FindAll())
            {
                sector.Deactivate();
                _flasher.Save(sector);
            }
        }
    }
}