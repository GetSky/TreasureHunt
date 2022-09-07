using Features.Sector.Repository;
using Features.Sector.View;
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
        private readonly ISectorFlasher _flasher;

        public SectorFactory(DiContainer container, ISectorFlasher flasher)
        {
            _container = container;
            _flasher = flasher;
        }

        public Sector Create(Vector2 position, bool treasure, Object prefab)
        {
            var obj = _container.InstantiatePrefabForComponent<View.Sector>(prefab);
            obj.transform.position = new Vector3(position.X, 0, position.Y);
            obj.SetTreasure(treasure);

            var entity = new Sector(obj.UniqueCode(), position, treasure);
            _flasher.Save(entity);

            var symbolModel = new SymbolModel(entity, obj);

            return entity;
        }
    }
}