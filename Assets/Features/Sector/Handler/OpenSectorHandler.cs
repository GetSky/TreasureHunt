using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class SectorOpenHandler : ISectorOpenHandler
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorContext _sectorContext;

        public SectorOpenHandler(ISectorRepository sectorRepo, ISectorContext sectorContext)
        {
            _sectorRepo = sectorRepo;
            _sectorContext = sectorContext;
        }

        public void Invoke(SectorOpenCommand command)
        {
            var sector = _sectorRepo.FindById(command.Id);
            var treasure = _sectorRepo.FindTreasure();
            if (treasure == null) return;

            sector.Open(treasure);
            _sectorContext.Save(sector);
        }
    }
}