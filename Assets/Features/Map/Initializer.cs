using Zenject;

namespace Features.Map
{
    public class Initializer : IInitializable
    {
        private readonly Factory _mapFactory;
        private readonly MapProducer _producer;

        public Initializer(Factory mapFactory, MapProducer producer)
        {
            _mapFactory = mapFactory;
            _producer = producer;
        }

        public void Initialize()
        {
            _mapFactory.Create();
            _producer.Generate(10, 10, 90);
        }
    }
}