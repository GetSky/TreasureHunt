using Features.Map.Event;
using Features.Map.Handler;
using Features.Map.Repository;
using Features.Sector.Event;
using UnityEngine;
using Zenject;

namespace Features.Map
{
    public class MapInstaller : Installer<MapInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Map, Factory>().FromFactory<MapFactory>();
            Container.Bind<MapProducer>().AsTransient().Lazy();
            Container.Bind<IRestartMapHandler>().To<RestartMapHandler>().AsSingle().Lazy();
            Container.Bind<IDeactivateMapHandler>().To<DeactivateMapHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(IMapFlasher), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<SectorConnector>().AsTransient().Lazy();

            Container.BindSignal<TreasureFind>().ToMethod<SectorConnector>(c => c.TreasureFind).FromResolve();

            Container.DeclareSignal<GameStatusChange>().OptionalSubscriber();
        }
    }
}