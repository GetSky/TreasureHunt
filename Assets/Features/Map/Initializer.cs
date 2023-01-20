using Core;
using Features.Map.Handler;
using Zenject;

namespace Features.Map
{
    public class Initializer : IInitializable
    {
        private readonly Factory _factory;
        private readonly IHandler<LoadMapCommand> _loadMapHandler;

        public Initializer(Factory factory, IHandler<LoadMapCommand> loadMapHandler)
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