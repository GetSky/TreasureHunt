using Core;
using Features.Map.Event;
using Features.Map.Handler;
using Features.Map.Repository;
using Features.Sector.Event;
using UnityEngine;
using Zenject;

namespace Features.Map
{
    public class Installer : Installer<GameObject, Installer>
    {
        private readonly GameObject _powerCountPrefab;

        public Installer(GameObject prefab)
        {
            _powerCountPrefab = prefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<Factory>().AsSingle().WithArguments(_powerCountPrefab).Lazy();
            Container.Bind<MapProducer>().AsTransient().Lazy();
            Container.Bind<IInteractor<LoadMapCommand>>().To<LoadMapInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<UnloadMapCommand>>().To<UnloadMapInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<DeactivateMapCommand>>().To<DeactivateMapInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<DecreaseTurnCountCommand>>().To<DecreaseTurnCountInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<RaiseTurnCountCommand>>().To<RaiseTurnCountInteractor>().AsSingle().Lazy();

            Container
                .Bind(typeof(IMapContext), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<SectorConnector>().AsTransient().Lazy();

            Container.BindSignal<TreasureFound>().ToMethod<SectorConnector>(c => c.TreasureFind).FromResolve();
            Container.BindSignal<EnergyFound>().ToMethod<SectorConnector>(c => c.EnergyFound).FromResolve();
            Container.BindSignal<SectorOpen>().ToMethod<SectorConnector>(c => c.SectorOpen).FromResolve();

            Container.DeclareSignal<GameStatusChanged>().OptionalSubscriber();
            Container.DeclareSignal<MapLoaded>().OptionalSubscriber();
            Container.DeclareSignal<MapUnloaded>().OptionalSubscriber();

            Container.Bind<IInitializable>().To<Initializer>().AsSingle();
        }
    }
}