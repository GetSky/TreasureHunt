using Features.Map.Repository;
using Features.Sector.Repository;

namespace Features.Map.Handler
{
    public class RestartMapHandler : IRestartMapHandler
    {
        private readonly ISectorRepository _repository;
        private readonly ISectorFlasher _flasher;
        private readonly MapProducer _producer;
        private readonly IMapFlasher _mapFlasher;

        public RestartMapHandler(
            ISectorRepository repository,
            ISectorFlasher flasher,
            MapProducer producer,
            IMapFlasher mapFlasher)
        {
            _repository = repository;
            _flasher = flasher;
            _producer = producer;
            _mapFlasher = mapFlasher;
        }

        public void Invoke(RestartMapCommand command)
        {
            foreach (var sector in _repository.FindAll()) sector.Destroy();
            _flasher.Clear();
            _mapFlasher.Save(_producer.Generate(10, 10, 90));
        }
    }
}