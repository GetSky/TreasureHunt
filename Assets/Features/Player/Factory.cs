using Features.Player.Repository;
using UnityEngine;
using Zenject;

namespace Features.Player
{
    public class Factory
    {
        private readonly DiContainer _container;
        private readonly IPlayerContext _context;
        private readonly GameObject _coinsCounterPrefab;

        public Factory(DiContainer container, IPlayerContext context, GameObject coinsCounterPrefab)
        {
            _container = container;
            _context = context;
            _coinsCounterPrefab = coinsCounterPrefab;
        }


        public Entity.Player Create(string id, int coins)
        {
            var entity = new Entity.Player(id, coins);
            _context.Save(entity);

            return entity;
        }
    }
}