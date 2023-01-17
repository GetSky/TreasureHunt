using Features.Player.Repository;
using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly IPlayerContext _context;
        private readonly GameObject _coinsCounterPrefab;

        public Initializer(
            DiContainer container,
            IPlayerContext context,
            GameObject coinsCounterPrefab
        )
        {
            _container = container;
            _context = context;
            _coinsCounterPrefab = coinsCounterPrefab;
        }

        public void Initialize()
        {
            var entity = new Entity.Player("local", 0);
            var view = _container.InstantiatePrefabForComponent<ICoinsView>(_coinsCounterPrefab);
            var model = new CoinsModel(entity);
            model.AddView(view);
            _context.Save(entity);
        }
    }
}