using Features.Map.Repository;

namespace Features.Map.Handler
{
    public class ReloadMapHandler : IReloadMapHandler
    {
        private readonly IMapRepository _repository;
        private readonly MapProducer _producer;
        private readonly IMapContext _context;

        public ReloadMapHandler(IMapRepository repository, MapProducer producer, IMapContext context)
        {
            _repository = repository;
            _producer = producer;
            _context = context;
        }

        public void Invoke(ReloadMapCommand command)
        {
            var map = _repository.FindCurrent();
            map.ReloadMap();
            _context.Save(map);

            _producer.Generate(10, 10, 90);
            _context.Save(map);
        }
    }
}