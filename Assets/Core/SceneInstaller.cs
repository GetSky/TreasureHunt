using Features.Map;
using Features.Sector;
using Features.Sector.Handler;
using Features.Sector.Repository;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace Core
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _groundPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<Vector2, bool, Object, Sector, Factory>().FromFactory<SectorFactory>();
            Container.Bind<MapProducer>().AsTransient().WithArguments(_groundPrefab).Lazy();

            Container.Bind<ISectorOpenHandler>().To<SectorOpenHandler>().AsSingle().Lazy();

            Container
                .Bind(typeof(ISectorRepository), typeof(ISectorFlasher))
                .To<MemorySectorRepository>()
                .AsSingle()
                .NonLazy();
        }

        public void Awake()
        {
            Container.Resolve<MapProducer>().Generate(8, 8);
        }
    }
}