using Features.Level.Event;
using Features.Sector.Domain;
using Features.Sector.Domain.Effects.Events;
using Features.Sector.Domain.Events;
using Features.Sector.EventHandlers;
using Features.Sector.UseCases;
using Features.Sector.UseCases.ActivateSectors;
using Features.Sector.UseCases.ClickOnSector;
using Features.Sector.UseCases.CreateSector;
using Features.Sector.UseCases.DeactivateSectors;
using Features.Sector.UseCases.HighlightSectorsAtDirection;
using Features.Sector.UseCases.HighlightSectorsAtDistance;
using Features.Sector.UseCases.OpenSector;
using Features.Sector.UseCases.RemoveSectors;
using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class SectorInstaller : MonoInstaller
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
            Container.DeclareSignal<SectorClicked>().OptionalSubscriber();
            Container.DeclareSignal<EmptyDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<HintDistanceDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<HintDirectionDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<EnergyDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<CoinDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<TreasureDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<RandomSectorsDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<HintEffectLocationDiscovered>().OptionalSubscriber();
            Container.DeclareSignal<BombDiscovered>().OptionalSubscriber();
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
            subContainer.Bind<IInteractor<ClickOnSectorCommand>>().To<ClickOnSectorInteractor>().AsTransient();

            subContainer
                .Bind<IInteractor<HighlightSectorsAtDirectionCommand>>()
                .To<HighlightSectorsAsDirectionInteractor>()
                .AsTransient();

            subContainer
                .BindSignal<HintDistanceDiscovered>()
                .ToMethod<HintDistanceDiscoveredHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();

            subContainer
                .BindSignal<HintDirectionDiscovered>()
                .ToMethod<HintDirectionHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();

            subContainer
                .BindSignal<GameStatusChanged>()
                .ToMethod<GameStatusChangedHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();

            subContainer
                .BindSignal<MapUnloaded>()
                .ToMethod<MapUploadedHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();

            subContainer
                .BindSignal<SectorClicked>()
                .ToMethod<SectorClickedHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();

            subContainer
                .BindSignal<RandomSectorsDiscovered>()
                .ToMethod<RandomSectorsDiscoveredHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();

            subContainer
                .BindSignal<HintEffectLocationDiscovered>()
                .ToMethod<HintEffectLocationDiscoveredHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();
            subContainer
                .BindSignal<BombDiscovered>()
                .ToMethod<BombDiscoveredHandler>((handler, domainEvent) => handler.Handle(domainEvent))
                .FromNew();
        }
    }
}