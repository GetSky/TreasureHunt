using Features.Map.Event;
using Features.Map.Handler;
using Features.Map.Repository;
using UnityEngine;
using Zenject;

namespace Features.Map
{
    public class MapInstaller : Installer<GameObject, MapInstaller>
    {
        private readonly GameObject _groundPrefab;

        public MapInstaller(GameObject groundPrefab)
        {
            _groundPrefab = groundPrefab;
        }

        public override void InstallBindings()
        {
            Container.BindFactory<Map, Features.Map.Factory>().FromFactory<MapFactory>();
            Container.Bind<MapProducer>().AsTransient().WithArguments(_groundPrefab).Lazy();
            Container.Bind<IRestartMapHandler>().To<RestartMapHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(IMapFlasher), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();

            Container.DeclareSignal<GameStatusChange>();
        }
    }
}