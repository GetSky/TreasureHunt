using System.Globalization;
using Features.Sector.Adapters;
using Features.Sector.Domain;
using Features.Sector.View;
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
            var sub = _container.CreateSubContainer();

            sub.Bind<Domain.Sector>().AsSingle();
            sub.Bind<SectorPresenter>().AsSingle();

            var obj = sub.InstantiatePrefabForComponent<SectorView>(_prefab);
            obj.transform.position = new Vector3(x, 0.0f, z);

            var entity = new Domain.Sector(
                x.ToString(CultureInfo.CurrentCulture) + z.ToString(CultureInfo.CurrentCulture),
                sub.Resolve<SectorPresenter>()
            );

            return entity;
        }
    }
}