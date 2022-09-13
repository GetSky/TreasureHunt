using Features.Sector.Repository;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace Features.Sector
{
    public class Factory : PlaceholderFactory<Vector2, CardType, Object, Sector>
    {
    }

    public class SectorFactory : IFactory<Vector2, CardType, Object, Sector>
    {
        private readonly DiContainer _container;
        private readonly Card.Factory _cardFactory;
        private readonly ISectorFlasher _flasher;

        public SectorFactory(DiContainer container, Card.Factory cardFactory, ISectorFlasher flasher)
        {
            _container = container;
            _cardFactory = cardFactory;
            _flasher = flasher;
        }

        public Sector Create(Vector2 position, CardType type, Object prefab)
        {
            var obj = _container.InstantiatePrefabForComponent<View.Sector>(prefab);
            obj.transform.position = new Vector3(position.X, 0, position.Y);

            var entity = new Sector(obj.UniqueCode(), position, _cardFactory.Create(type));
            _flasher.Save(entity);

            var symbolModel = new SymbolModel(entity);
            symbolModel.AddView(obj);

            var highlightedModel = new HighlightedModel(entity);
            highlightedModel.AddView(obj);

            return entity;
        }
    }
}