using Features.Map.Event;
using Features.Map.Handler;
using Features.Map.Repository;
using Features.Sector.Event;
using Zenject;

namespace Features.Map
{
    public class MapInstaller : Installer<MapInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Map, Factory>().FromFactory<MapFactory>();
            Container.Bind<MapProducer>().AsTransient().Lazy();
            Container.Bind<IReloadMapHandler>().To<ReloadMapHandler>().AsSingle().Lazy();
            Container.Bind<IDeactivateMapHandler>().To<DeactivateMapHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(IMapContext), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<SectorConnector>().AsTransient().Lazy();

            Container.BindSignal<TreasureFound>().ToMethod<SectorConnector>(c => c.TreasureFind).FromResolve();

            Container.DeclareSignal<GameStatusChanged>().OptionalSubscriber();
            Container.DeclareSignal<MapReloaded>().OptionalSubscriber();

            Container.Bind<IInitializable>().To<Initializer>().AsSingle();
        }
    }
}