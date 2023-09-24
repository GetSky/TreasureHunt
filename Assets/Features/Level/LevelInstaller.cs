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
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _powerCountPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<Gateway>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallGateway)
                .WithGameObjectName("LevelLevel")
                .AsSingle()
                .NonLazy();

            Container.DeclareSignal<GameStatusChanged>().OptionalSubscriber();
            Container.DeclareSignal<LevelLoaded>().OptionalSubscriber();
            Container.DeclareSignal<LevelUnloaded>().OptionalSubscriber();
        }

        private void InstallGateway(DiContainer subContainer)
        {
            subContainer.Bind<Gateway>().AsSingle();

            subContainer.Bind<Factory>().AsSingle().WithArguments(_powerCountPrefab).Lazy();
            subContainer.Bind<LevelProducer>().AsTransient().Lazy();
            subContainer.Bind<IInteractor<LoadLevelCommand>>().To<LoadLevelInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<UnloadLevelCommand>>().To<UnloadLevelInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<DeactivateLevelCommand>>().To<DeactivateLevelInteractor>().AsSingle().Lazy();
            subContainer.Bind<IInteractor<DecreaseTurnCountCommand>>().To<DecreaseTurnCountInteractor>().AsSingle()
                .Lazy();
            subContainer.Bind<IInteractor<RaiseTurnCountCommand>>().To<RaiseTurnCountInteractor>().AsSingle().Lazy();

            subContainer
                .Bind(typeof(IEnergyPresenter), typeof(IEnergyPresenterBoundary))
                .To<EnergyPresenter>()
                .AsSingle()
                .NonLazy();

            subContainer
                .Bind(typeof(ILevelContext), typeof(ILevelRepository))
                .To<MemoryLevelRepository>()
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