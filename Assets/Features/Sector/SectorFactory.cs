using System.Globalization;
using Features.Sector.Adapters;
using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class SectorFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public SectorFactory(DiContainer container, GameObject prefab)
        {
            _container = container;
            _prefab = prefab;
        }

        public Domain.Sector Create(float x, float z)
        {
            var subContainer = _container.CreateSubContainer();
            var id = x.ToString(CultureInfo.CurrentCulture) + z.ToString(CultureInfo.CurrentCulture);
            var entity = new Domain.Sector(id);

            subContainer.Bind<Domain.Sector>().FromInstance(entity).AsSingle();

            CreateView(subContainer, x, z);

            return entity;
        }

        private void CreateView(DiContainer container, float x, float z)
        {
            container.Bind<SectorPresenter>().AsSingle();
            var gameObject = container.InstantiatePrefab(_prefab);
            gameObject.transform.position = new Vector3(x, 0.0f, z);
        }
    }
}