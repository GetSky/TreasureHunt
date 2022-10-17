using Features.Sector.Repository;

namespace Features.Sector.Handler
{
    public class RemoveSectorsHandler : IRemoveSectorsHandler
    {
        private readonly ISectorFlasher _flasher;
        private readonly ISectorRepository _repository;

        public RemoveSectorsHandler(ISectorFlasher flasher, ISectorRepository repository)
        {
            _flasher = flasher;
            _repository = repository;
        }

        public void Invoke(RemoveSectorsCommand command)
        {
            foreach (var sector in _repository.FindInactive())
            {
                sector.Destroy();
                _flasher.Remove(sector);
            }
        }
    }
}