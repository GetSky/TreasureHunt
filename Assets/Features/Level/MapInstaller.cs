using Core;
using Features.Level.Adapters;
using Features.Level.Commands;
using Features.Level.Entity;
using Features.Level.Event;
using Features.Level.UseCases;
using Features.Sector.Domain.Effects.Events;
using Features.Sector.Domain.Events;
using UnityEngine;
using Zenject;

namespace Features.Level
{
    public class MapInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _powerCountPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<Gateway>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallGateway)
                .WithGameObjectName("Map")
                .AsSingle()
                .NonLazy();

            Container.DeclareSignal<GameStatusChanged>().OptionalSubscriber();
            Container.DeclareSignal<MapLoaded>().OptionalSubscriber();
            Container.DeclareSignal<MapUnloaded>().OptionalSubscriber();
        }

        private void InstallGateway(DiContainer subContainer)
        {
            subContainer.Bind<Gateway>().AsSingle();

            subContainer.Bind<Factory>().AsSingle().WithArguments(_powerCountPrefab).Lazy();
            subContainer.Bind<MapProducer>().AsTransient().Lazy();
            subContainer.Bind<IInteractor<LoadMapCommand>>().To<LoadMapInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<UnloadMapCommand>>().To<UnloadMapInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<DeactivateMapCommand>>().To<DeactivateMapInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<DecreaseTurnCountCommand>>().To<DecreaseTurnCountInteractor>().AsSingle()
                .Lazy();
            subContainer.Bind<IInteractor<RaiseTurnCountCommand>>().To<RaiseTurnCountInteractor>().AsSingle().Lazy();

            subContainer
                .Bind(typeof(IEnergyPresenter), typeof(IEnergyPresenterBoundary))
                .To<EnergyPresenter>()
                .AsSingle()
                .NonLazy();

            subContainer
                .Bind(typeof(IMapContext), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();

            subContainer.Bind<SectorConnector>().AsTransient().Lazy();

            subContainer.BindSignal<TreasureDiscovered>().ToMethod<SectorConnector>(c => c.DeactivateMap).FromResolve();
            subContainer.BindSignal<EnergyDiscovered>().ToMethod<SectorConnector>(c => c.EnergyFound).FromResolve();
            subContainer.BindSignal<SectorClicked>().ToMethod<SectorConnector>(c => c.TurnCount).FromResolve();

            subContainer.Bind<IInitializable>().To<Initializer>().AsSingle();
        }
    }
}