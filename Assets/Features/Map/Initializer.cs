using Zenject;

namespace Features.Map
{
    public class Initializer : IInitializable
    {
        private readonly Factory _factory;
        private readonly MapProducer _producer;

        public Initializer(Factory factory, MapProducer producer)
        {
            _factory = factory;
            _producer = producer;
        }

        public void Initialize()
        {
            var dd = _factory.Create();
            _producer.Generate(10, 10, 90);
        }
    }
}