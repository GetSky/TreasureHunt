using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class ActivateSectorsHandler : IActivateSectorsHandler
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorContext _context;

        public ActivateSectorsHandler(ISectorRepository sectorRepo, ISectorContext context)
        {
            _sectorRepo = sectorRepo;
            _context = context;
        }

        public void Invoke(ActivateSectorsCommand command)
        {
            foreach (var sector in _sectorRepo.FindAll())
            {
                sector.Activate();
                _context.Save(sector);
            }
        }
    }
}