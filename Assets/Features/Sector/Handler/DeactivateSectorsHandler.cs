using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class DeactivateSectorsHandler : IDeactivateSectorsHandler
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorContext _context;

        public DeactivateSectorsHandler(ISectorRepository sectorRepo, ISectorContext context)
        {
            _sectorRepo = sectorRepo;
            _context = context;
        }

        public void Invoke(DeactivateSectorsCommand command)
        {
            foreach (var sector in _sectorRepo.FindAll())
            {
                sector.Deactivate();
                _context.Save(sector);
            }
        }
    }
}