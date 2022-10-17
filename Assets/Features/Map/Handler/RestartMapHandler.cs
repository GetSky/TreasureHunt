using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class RestartMapHandler : IRestartMapHandler
    {
        private readonly IMapRepository _repository;
        private readonly MapProducer _producer;
        private readonly IMapFlasher _mapFlasher;

        public RestartMapHandler(IMapRepository repository, MapProducer producer, IMapFlasher mapFlasher)
        {
            _repository = repository;
            _producer = producer;
            _mapFlasher = mapFlasher;
        }

        public void Invoke(RestartMapCommand command)
        {
            var map = _repository.FindCurrent();
            map.ResetMap();
            _mapFlasher.Save(map);

            _producer.Generate(10, 10, 90);
        }
    }
}