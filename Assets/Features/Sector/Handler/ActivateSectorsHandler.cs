using Core;
using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class ActivateSectorsInteractor : IInteractor<ActivateSectorsCommand>
    {
        private readonly ISectorRepository _sectorRepo;
        private readonly ISectorContext _context;

        public ActivateSectorsInteractor(ISectorRepository sectorRepo, ISectorContext context)
        {
            _sectorRepo = sectorRepo;
            _context = context;
        }

        public void Execute(ActivateSectorsCommand command)
        {
            foreach (var sector in _sectorRepo.FindAll())
            {
                sector.Activate();
                _context.Save(sector);
            }
        }
    }
}