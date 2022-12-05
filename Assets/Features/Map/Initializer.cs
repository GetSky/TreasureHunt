using Features.Map.Handler;
using Zenject;

namespace Features.Map
{
    public class Initializer : IInitializable
    {
        private readonly Factory _factory;
        private readonly ILoadMapHandler _loadMapHandler;

        public Initializer(Factory factory, ILoadMapHandler loadMapHandler)
        {
            _factory = factory;
            _loadMapHandler = loadMapHandler;
        }

        public void Initialize()
        {
            _factory.Create();
            _loadMapHandler.Invoke(new LoadMapCommand());
        }
    }
}