using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class Factory
    {
        private readonly DiContainer _container;
        private readonly GameObject _coinsCounterPrefab;

        public Factory(DiContainer container, GameObject coinsCounterPrefab)
        {
            _container = container;
            _coinsCounterPrefab = coinsCounterPrefab;
        }

        public Entity.Player Create(string id, int coins)
        {
            var entity = new Entity.Player(id, coins);
            var view = _container.InstantiatePrefabForComponent<ICoinsView>(_coinsCounterPrefab);
            var model = new CoinsModel(entity);
            model.AddView(view);

            return entity;
        }
    }
}