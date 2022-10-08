using Features.EndGameMenu.View;
using Features.Map;
using Features.Map.Handler;
using Features.Map.Repository;
using Features.Sector;
using Features.Sector.Card;
using Features.Sector.Handler;
using Features.Sector.Repository;
using UnityEngine;
using Zenject;
using Factory = Features.Sector.Factory;
using Vector2 = System.Numerics.Vector2;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _groundPrefab;
        [SerializeField] private GameObject _endGameMenuPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<Vector2, CardType, Object, Sector, Factory>().FromFactory<SectorFactory>();
            Container.BindFactory<CardType, ICard, Features.Sector.Card.Factory>().FromFactory<CardFactory>();
            Container.BindFactory<Map, Features.Map.Factory>().FromFactory<MapFactory>();

            Container.Bind<MapProducer>().AsTransient().WithArguments(_groundPrefab).Lazy();

            Container.Bind<ISectorOpenHandler>().To<SectorOpenHandler>().AsSingle().Lazy();
            Container.Bind<IRestartMapHandler>().To<RestartMapHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(ISectorRepository), typeof(ISectorFlasher))
                .To<MemorySectorRepository>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind(typeof(IMapFlasher), typeof(IMapRepository))
                .To<MemoryMapRepository>()
                .AsSingle()
                .NonLazy();
        }

        public void Awake()
        {
            var map = Container.Resolve<Features.Map.Factory>().Create();
            var endMenu = Container.InstantiatePrefabForComponent<EndGameMenu>(_endGameMenuPrefab);

            Container.Resolve<MapProducer>().Generate(10, 10, 90);
        }
    }
}