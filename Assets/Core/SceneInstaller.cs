using Features.Field;
using Features.Sector;
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
            Container.Bind<FieldProducer>().AsTransient().WithArguments(_groundPrefab).Lazy();
        }

        public void Awake()
        {
            Container.Resolve<FieldProducer>().Generate(8, 8);
        }
    }
}