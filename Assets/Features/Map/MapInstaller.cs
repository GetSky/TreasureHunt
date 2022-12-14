using Features.Map.Event;
using Features.Map.Handler;
using Features.Map.Repository;
using Features.Sector.Event;
using UnityEngine;
using Zenject;

namespace Features.Map
{
    public class MapInstaller : Installer<GameObject, MapInstaller>
    {
        private readonly GameObject _powerCountPrefab;

        public MapInstaller(GameObject prefab)
        {
            _powerCountPrefab = prefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<Factory>().AsSingle().WithArguments(_powerCountPrefab).Lazy();
            Container.Bind<MapProducer>().AsTransient().Lazy();
            Container.Bind<ILoadMapHandler>().To<LoadMapHandler>().AsSingle().Lazy();
            Container.Bind<IUnloadMapCommand>().To<UnloadMapHandler>().AsSingle().Lazy();
            Container.Bind<IDeactivateMapHandler>().To<DeactivateMapHandler>().AsSingle().Lazy();
            Container.Bind<IDecreaseTurnCountHandler>().To<DecreaseTurnCountHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(IMapContext), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<SectorConnector>().AsTransient().Lazy();

            Container.BindSignal<TreasureFound>().ToMethod<SectorConnector>(c => c.TreasureFind).FromResolve();
            Container.BindSignal<SectorOpen>().ToMethod<SectorConnector>(c => c.SectorOpen).FromResolve();

            Container.DeclareSignal<GameStatusChanged>().OptionalSubscriber();
            Container.DeclareSignal<MapLoaded>().OptionalSubscriber();
            Container.DeclareSignal<MapUnloaded>().OptionalSubscriber();

            Container.Bind<IInitializable>().To<Initializer>().AsSingle();
        }
    }
}