using Features.OldSector.Adapters;
using Features.OldSector.Card;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace Features.OldSector
{
    public class Factory
    {
        private readonly DiContainer _container;
        private readonly Card.Factory _cardFactory;
        private readonly GameObject _prefab;

        public Factory(DiContainer container, Card.Factory cardFactory, GameObject prefab)
        {
            _container = container;
            _cardFactory = cardFactory;
            _prefab = prefab;
        }

        public Entities.Sector Create(Vector2 position, CardType type)
        {
            var obj = _container.InstantiatePrefabForComponent<Sector.View.Sector>(_prefab);
            obj.transform.position = new Vector3(position.X, 0, position.Y);

            var entity = new Entities.Sector(obj.UniqueCode(), position, _cardFactory.Create(type));

            var symbolModel = new SymbolPresenter(entity, obj);

            var highlightedPresenter = new HighlightedPresenter(entity, obj);

            return entity;
        }
    }
}