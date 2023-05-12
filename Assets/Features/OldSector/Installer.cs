using Core;
using Features.Map.Event;
using Features.OldSector.Adapters;
using Features.OldSector.Card;
using Features.OldSector.Commands;
using Features.OldSector.Entities;
using Features.OldSector.Event;
using Features.OldSector.UseCases;
using Features.Sector;
using UnityEngine;
using Zenject;

namespace Features.OldSector
{
    public class Installer : Installer<GameObject, Installer>
    {
        private readonly GameObject _groundPrefab;

        public Installer(GameObject prefab)
        {
            _groundPrefab = prefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<Factory>().AsSingle().WithArguments(_groundPrefab).Lazy();
            Container.BindFactory<CardType, ICard, Card.Factory>().FromFactory<CardFactory>();

            Container.Bind<MapConnector>().AsTransient().Lazy();

            InstallHandlers();
            InstallRepositories();
            BindSignals();
            DeclareSignals();
        }

        private void InstallHandlers()
        {
            Container.Bind<IInteractor<SectorOpenCommand>>().To<SectorOpenInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<DeactivateSectorsCommand>>().To<DeactivateSectorsInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<RemoveSectorsCommand>>().To<RemoveSectorsInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<ActivateSectorsCommand>>().To<ActivateSectorsInteractor>().AsSingle().Lazy();
            Container.Bind<IInteractor<CreateSectorCommand>>().To<CreateSectorInteractor>().AsSingle().Lazy();
            Container
                .Bind<IInteractor<HighlightSectorsAtDistanceCommand>>()
                .To<HighlightSectorsAtDistanceInteractor>()
                .AsSingle()
                .Lazy();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<SectorOpen>();
            Container.DeclareSignal<TreasureFound>();
            Container.DeclareSignal<CoinFound>();
            Container.DeclareSignal<EnergyFound>();
            Container.DeclareSignal<CreateSectorCommand>();
            Container.DeclareSignal<HighlightSectorsAtDistanceCommand>();
        }

        private void BindSignals()
        {
            Container
                .BindSignal<GameStatusChanged>()
                .ToMethod<MapConnector>(connector => connector.GameStatusChange)
                .FromResolve();
            Container
                .BindSignal<MapUnloaded>()
                .ToMethod<MapConnector>(connector => connector.UnloadMap)
                .FromResolve();
            Container
                .BindSignal<CreateSectorCommand>()
                .ToMethod<IInteractor<CreateSectorCommand>>(handler => handler.Execute)
                .FromResolve();
            Container
                .BindSignal<HighlightSectorsAtDistanceCommand>()
                .ToMethod<IInteractor<HighlightSectorsAtDistanceCommand>>(handler => handler.Execute)
                .FromResolve();
        }

        private void InstallRepositories()
        {
            Container
                .Bind(typeof(ISectorRepository), typeof(ISectorContext))
                .To<MemorySectorRepository>()
                .AsSingle()
                .NonLazy();
        }
    }
}