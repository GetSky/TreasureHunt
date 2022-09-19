using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class SectorOpenHandler : ISectorOpenHandler
    {
        private readonly ISectorRepository _repository;

        public SectorOpenHandler(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Invoke(SectorOpenCommand command)
        {
            var sector = _repository.FindById(command.Id);
            var treasure = _repository.FindTreasure();
            if (treasure == null) return;

            sector.Open(treasure);
            foreach (var sec in _repository.FindAll()) sec.Highlight(sector);
        }
    }
}