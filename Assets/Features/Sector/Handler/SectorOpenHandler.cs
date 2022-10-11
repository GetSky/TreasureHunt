using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class SectorOpenHandler : ISectorOpenHandler
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorFlasher _sectorFlasher;

        public SectorOpenHandler(ISectorRepository sectorRepo, ISectorFlasher sectorFlasher)
        {
            _sectorRepo = sectorRepo;
            _sectorFlasher = sectorFlasher;
        }

        public void Invoke(SectorOpenCommand command)
        {

            var sector = _sectorRepo.FindById(command.Id);
            var treasure = _sectorRepo.FindTreasure();
            if (treasure == null) return;

            sector.Open(treasure);
            foreach (var sec in _sectorRepo.FindAll()) sec.Highlight(sector);

            _sectorFlasher.Save(sector);
        }
    }
}