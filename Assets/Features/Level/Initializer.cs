using Core;
using Features.Level.Commands;
using Zenject;

namespace Features.Level
{
    public class Initializer : IInitializable
    {
        private readonly Factory _factory;
        private readonly IInteractor<LoadLevelCommand> _loadMapInteractor;

        public Initializer(Factory factory, IInteractor<LoadLevelCommand> loadMapInteractor)
        {
            _factory = factory;
            _loadMapInteractor = loadMapInteractor;
        }

        public void Initialize()
        {
            _factory.Create();
            _loadMapInteractor.Execute(new LoadLevelCommand());
        }
    }
}