using Core;
using Features.OldSector.Commands;
using Features.OldSector.Entities;

namespace Features.OldSector.UseCases
{
    public class SectorOpenInteractor : IInteractor<SectorOpenCommand>
    {
        private readonly ISectorRepository _repository;
        private readonly ISectorContext _context;

        public SectorOpenInteractor(ISectorRepository repository, ISectorContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Execute(SectorOpenCommand command)
        {
            var sector = _repository.FindById(command.Id);
            var treasure = _repository.FindTreasure();
            if (treasure is null || sector is null) return;

            sector.OpenWithTreasureIn(treasure);
            _context.Save(sector);
        }
    }
}