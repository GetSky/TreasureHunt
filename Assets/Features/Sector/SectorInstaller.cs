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

            Container.Bind<ISectorOpenHandler>().To<SectorOpenHandler>().AsSingle().Lazy();
            Container.Bind<IDeactivateSectorsHandler>().To<DeactivateSectorsHandler>().AsSingle().Lazy();
            Container.Bind<IRemoveSectorsHandler>().To<RemoveSectorsHandler>().AsSingle().Lazy();
            Container.Bind<IActivateSectorsHandler>().To<ActivateSectorsHandler>().AsSingle().Lazy();
            Container.Bind<ICreateSectorHandler>().To<CreateSectorHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(ISectorRepository), typeof(ISectorFlasher))
                .To<MemorySectorRepository>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MapConnector>().AsTransient().Lazy();
            Container.BindSignal<GameStatusChange>().ToMethod<MapConnector>(c => c.GameStatusChange).FromResolve();
            Container.BindSignal<ResetMap>().ToMethod<MapConnector>(c => c.ResetMap).FromResolve();
            
            Container.DeclareSignal<CreateSectorCommand>();
            Container.BindSignal<CreateSectorCommand>().ToMethod<ICreateSectorHandler>(c => c.Invoke).FromResolve();

            Container.DeclareSignal<TreasureFind>();
        }
    }
}