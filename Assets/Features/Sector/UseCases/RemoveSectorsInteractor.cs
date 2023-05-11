using Core;
using Features.Sector.Commands;
using Features.Sector.Entities;
using Features.Sector.Repository;

namespace Features.Sector.UseCases
{
    public class RemoveSectorsInteractor : IInteractor<RemoveSectorsCommand>
    {
        private readonly ISectorContext _context;
        private readonly ISectorRepository _repository;

        public RemoveSectorsInteractor(ISectorContext context, ISectorRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public void Execute(RemoveSectorsCommand command)
        {
            foreach (var sector in _repository.FindInactive())
            {
                sector.Destroy();
                _context.Remove(sector);
            }
        }
    }
}