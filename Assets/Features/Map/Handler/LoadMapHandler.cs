using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class LoadMapHandler : ILoadMapHandler
    {
        private readonly IMapRepository _repository;
        private readonly MapProducer _producer;
        private readonly IMapContext _context;

        public LoadMapHandler(IMapRepository repository, MapProducer producer, IMapContext context)
        {
            _repository = repository;
            _producer = producer;
            _context = context;
        }

        public void Invoke(LoadMapCommand command)
        {
            var map = _producer.Generate(10, 10, 90);
            _context.Save(map);
        }
    }
}