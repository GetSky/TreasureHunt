using Features.Map.Repository;
using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class SectorOpenHandler : ISectorOpenHandler
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly IMapRepository _mapRepo;

        public SectorOpenHandler(ISectorRepository sectorRepo, IMapRepository mapRepo)
        {
            _sectorRepo = sectorRepo;
            _mapRepo = mapRepo;
        }

        public void Invoke(SectorOpenCommand command)
        {
            var map = _mapRepo.FindActive();
            if (map == null) return;

            var sector = _sectorRepo.FindById(command.Id);
            var treasure = _sectorRepo.FindTreasure();
            if (treasure == null) return;

            sector.Open(treasure);
            foreach (var sec in _sectorRepo.FindAll()) sec.Highlight(sector);
            
            if (sector.Card.Type() == CardType.Treasure) map.Deactivate();
        }
    }
}