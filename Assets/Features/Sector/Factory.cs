using Features.Sector.Card;
using Features.Sector.Repository;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace Features.Sector
{
    public class Factory
    {
        private readonly DiContainer _container;
        private readonly Card.Factory _cardFactory;
        private readonly ISectorContext _context;
        private readonly GameObject _prefab;

        public Factory(DiContainer container, Card.Factory cardFactory, ISectorContext context, GameObject prefab)
        {
            _container = container;
            _cardFactory = cardFactory;
            _context = context;
            _prefab = prefab;
        }

        public Sector Create(Vector2 position, CardType type)
        {
            var obj = _container.InstantiatePrefabForComponent<View.Sector>(_prefab);
            obj.transform.position = new Vector3(position.X, 0, position.Y);

            var entity = new Sector(obj.UniqueCode(), position, _cardFactory.Create(type));
            _context.Save(entity);

            var symbolModel = new SymbolModel(entity);
            symbolModel.AddView(obj);

            var highlightedModel = new HighlightedModel(entity);
            highlightedModel.AddView(obj);

            return entity;
        }
    }
}