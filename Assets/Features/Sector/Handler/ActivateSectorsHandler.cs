using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class ActivateSectorsHandler : IActivateSectorsHandler
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorFlasher _flasher;

        public ActivateSectorsHandler(ISectorRepository sectorRepo, ISectorFlasher flasher)
        {
            _sectorRepo = sectorRepo;
            _flasher = flasher;
        }

        public void Invoke(ActivateSectorsCommand command)
        {
            foreach (var sector in _sectorRepo.FindAll())
            {
                sector.Activate();
                _flasher.Save(sector);
            }
        }
    }
}