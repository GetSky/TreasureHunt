using Core;
using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class SectorOpenInteractor : IInteractor<SectorOpenCommand>
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorContext _sectorContext;

        public SectorOpenInteractor(ISectorRepository sectorRepo, ISectorContext sectorContext)
        {
            _sectorRepo = sectorRepo;
            _sectorContext = sectorContext;
        }

        public void Execute(SectorOpenCommand command)
        {
            var sector = _sectorRepo.FindById(command.Id);
            var treasure = _sectorRepo.FindTreasure();
            if (treasure == null) return;

            sector.OpenWithTreasureIn(treasure);
            _sectorContext.Save(sector);
        }
    }
}