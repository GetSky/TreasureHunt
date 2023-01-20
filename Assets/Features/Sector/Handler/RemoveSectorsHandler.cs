using Core;
using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class RemoveSectorsHandler : IHandler<RemoveSectorsCommand>
    {
        private readonly ISectorContext _context;
        private readonly ISectorRepository _repository;

        public RemoveSectorsHandler(ISectorContext context, ISectorRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public void Invoke(RemoveSectorsCommand command)
        {
            foreach (var sector in _repository.FindInactive())
            {
                sector.Destroy();
                _context.Remove(sector);
            }
        }
    }
}