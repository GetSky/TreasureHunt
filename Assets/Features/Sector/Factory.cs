using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace Features.Sector
{
    public class Factory : PlaceholderFactory<Vector2, bool, Object, Sector>
    {
    }

    public class SectorFactory : IFactory<Vector2, bool, Object, Sector>
    {
        private readonly DiContainer _container;

        public SectorFactory(DiContainer container)
        {
            _container = container;
        }

        public Features.Sector.Sector Create(Vector2 position, bool treasure, Object prefab)
        {
            var obj = _container.InstantiatePrefabForComponent<SectorView>(prefab);
            obj.transform.position = new Vector3(position.X, 0, position.Y);
            obj.SetTreasure(treasure);

            return new Features.Sector.Sector(position, treasure);
        }
    }
}