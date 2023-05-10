using Core;
using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class DeactivateSectorsInteractor : IInteractor<DeactivateSectorsCommand>
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorContext _context;

        public DeactivateSectorsInteractor(ISectorRepository sectorRepo, ISectorContext context)
        {
            _sectorRepo = sectorRepo;
            _context = context;
        }

        public void Execute(DeactivateSectorsCommand command)
        {
            foreach (var sector in _sectorRepo.FindAll())
            {
                sector.Deactivate();
                _context.Save(sector);
            }
        }
    }
}