using Core;
using Features.Map.Adapters;
using Features.Map.Commands;
using Features.Map.Entity;
using Features.Map.Event;
using Features.Map.UseCases;
using Features.Sector.Domain.Effects.Events;
using Features.Sector.Domain.Events;
using UnityEngine;
using Zenject;

namespace Features.Map
{
    public class MapInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _powerCountPrefab;
        
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
                .Bind(typeof(IEnergyPresenter), typeof(IEnergyPresenterBoundary))
                .To<EnergyPresenter>()
                .AsSingle()
                .NonLazy();           
            
            Container
                .Bind(typeof(IMapContext), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<SectorConnector>().AsTransient().Lazy();

            Container.BindSignal<TreasureDiscovered>().ToMethod<SectorConnector>(c => c.DeactivateMap).FromResolve();
            Container.BindSignal<EnergyDiscovered>().ToMethod<SectorConnector>(c => c.EnergyFound).FromResolve();
            Container.BindSignal<SectorClicked>().ToMethod<SectorConnector>(c => c.TurnCount).FromResolve();

            Container.DeclareSignal<GameStatusChanged>().OptionalSubscriber();
            Container.DeclareSignal<MapLoaded>().OptionalSubscriber();
            Container.DeclareSignal<MapUnloaded>().OptionalSubscriber();

            Container.Bind<IInitializable>().To<Initializer>().AsSingle();
        }
    }
}