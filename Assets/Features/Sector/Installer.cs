using Features.Map.Event;
using Features.Sector.Domain;
using Features.Sector.Domain.Effects.Events;
using Features.Sector.Domain.Events;
using Features.Sector.EventHandlers;
using Features.Sector.UseCases;
using Features.Sector.UseCases.ActivateSectors;
using Features.Sector.UseCases.CreateSector;
using Features.Sector.UseCases.DeactivateSectors;
using Features.Sector.UseCases.HighlightSectorsAtDistance;
using Features.Sector.UseCases.OpenSector;
using Features.Sector.UseCases.RemoveSectors;
using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class Installer : MonoInstaller
    {
        [SerializeField] private GameObject _prefab;

        public override void InstallBindings()

        {
            Container
                .Bind<Gateway>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallGateway)
                .WithGameObjectName("Sectors")
                .AsSingle()
                .NonLazy();

            Container.DeclareSignal<SectorOpened>().OptionalSubscriber();
            Container.DeclareSignal<EmptyDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<HintDistanceDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<EnergyDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<CoinDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<TreasureDiscovered>().OptionalSubscriber();
        }

        private void InstallGateway(DiContainer subContainer)
        {
            subContainer.Bind<Gateway>().AsSingle();

            subContainer.Bind<SectorFactory>().AsSingle().WithArguments(subContainer, _prefab);
            subContainer.Bind<ISectorRepository>().To<SectorMemoryRepository>().AsSingle();

            subContainer.Bind<IInteractor<CreateSectorCommand>>().To<CreateSectorInteractor>().AsTransient();
            subContainer.Bind<IInteractor<ActivateSectorsCommand>>().To<ActivateSectorsInteractor>().AsTransient();
            subContainer.Bind<IInteractor<DeactivateSectorsCommand>>().To<DeactivateSectorsInteractor>().AsTransient();

            subContainer
                .Bind<IInteractor<HighlightSectorsAtDistanceCommand>>()
                .To<HighlightSectorsAtDistanceInteractor>()
                .AsTransient();

            subContainer.Bind<IInteractor<RemoveSectorsCommand>>().To<RemoveSectorsInteractor>().AsTransient();
            subContainer.Bind<IInteractor<OpenSectorCommand>>().To<OpenSectorInteractor>().AsTransient();

            subContainer
                .BindSignal<HintDistanceDiscovered>()
                .ToMethod<HintDistanceDiscoveredHandler>((handler, discovered) => handler.Execute(discovered))
                .FromNew();

            subContainer
                .BindSignal<GameStatusChanged>()
                .ToMethod<GameStatusChangedHandler>((handler, discovered) => handler.Execute(discovered))
                .FromNew();
            
            subContainer
                .BindSignal<MapUnloaded>()
                .ToMethod<MapUploadedHandler>((handler, discovered) => handler.Execute(discovered))
                .FromNew();
        }
    }
}