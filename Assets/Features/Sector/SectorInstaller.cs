using Core;
using Features.Map.Event;
using Features.Sector.Card;
using Features.Sector.Event;
using Features.Sector.Handler;
using Features.Sector.Repository;
using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class SectorInstaller : Installer<GameObject, SectorInstaller>
    {
        private readonly GameObject _groundPrefab;

        public SectorInstaller(GameObject prefab)
        {
            _groundPrefab = prefab;
        }

        public override void InstallBindings()
        {
            Container.Bind<Factory>().AsSingle().WithArguments(_groundPrefab).Lazy();
            Container.BindFactory<CardType, ICard, Features.Sector.Card.Factory>().FromFactory<CardFactory>();

            Container.Bind<MapConnector>().AsTransient().Lazy();

            InstallHandlers();
            InstallRepositories();
            BindSignals();
            DeclareSignals();
        }

        private void InstallHandlers()
        {
            Container.Bind<IHandler<SectorOpenCommand>>().To<SectorOpenHandler>().AsSingle().Lazy();
            Container.Bind<IHandler<DeactivateSectorsCommand>>().To<DeactivateSectorsHandler>().AsSingle().Lazy();
            Container.Bind<IHandler<RemoveSectorsCommand>>().To<RemoveSectorsHandler>().AsSingle().Lazy();
            Container.Bind<IHandler<ActivateSectorsCommand>>().To<ActivateSectorsHandler>().AsSingle().Lazy();
            Container.Bind<IHandler<CreateSectorCommand>>().To<CreateSectorHandler>().AsSingle().Lazy();
            Container
                .Bind<IHandler<HighlightSectorsAtDistanceCommand>>()
                .To<HighlightSectorsAtDistanceHandler>()
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
                .ToMethod<IHandler<CreateSectorCommand>>(handler => handler.Invoke)
                .FromResolve();
            Container
                .BindSignal<HighlightSectorsAtDistanceCommand>()
                .ToMethod<IHandler<HighlightSectorsAtDistanceCommand>>(handler => handler.Invoke)
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