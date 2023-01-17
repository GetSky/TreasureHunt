using Features.Player.Repository;
using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class Initializer : IInitializable
    {
        private readonly DiContainer _container;
        private readonly IPlayerContext _context;
        private readonly IPlayerRepository _repository;
        private readonly GameObject _coinsCounterPrefab;

        public Initializer(
            DiContainer container,
            IPlayerContext context,
            IPlayerRepository repository,
            GameObject coinsCounterPrefab
        )
        {
            _container = container;
            _context = context;
            _repository = repository;
            _coinsCounterPrefab = coinsCounterPrefab;
        }

        public void Initialize()
        {
            var entity = _repository.FindCurrent();
            var view = _container.InstantiatePrefabForComponent<ICoinsView>(_coinsCounterPrefab);
            var model = new CoinsModel(entity);
            model.AddView(view);
            _context.Save(entity);
        }
    }
}