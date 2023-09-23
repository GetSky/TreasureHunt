using Features.Level.Entity;
using UnityEngine;
using Zenject;

namespace Features.Level
{
    public class Factory
    {
        private readonly DiContainer _container;
        private readonly IMapContext _context;
        private readonly GameObject _powerCountPrefab;

        public Factory(DiContainer container, IMapContext context, GameObject powerCountPrefab)
        {
            _container = container;
            _context = context;
            _powerCountPrefab = powerCountPrefab;
        }

        public Level.Entity.Map Create()
        {
            _container.InstantiatePrefab(_powerCountPrefab).name = _powerCountPrefab.name;
            var entity = new Level.Entity.Map("map", 6);
            _context.Save(entity);
            return entity;
        }
    }
}