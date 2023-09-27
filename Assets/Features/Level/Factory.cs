using Features.Level.Domain;
using UnityEngine;
using Zenject;

namespace Features.Level
{
    public class Factory
    {
        private readonly DiContainer _container;
        private readonly ILevelContext _context;
        private readonly GameObject _powerCountPrefab;

        public Factory(DiContainer container, ILevelContext context, GameObject powerCountPrefab)
        {
            _container = container;
            _context = context;
            _powerCountPrefab = powerCountPrefab;
        }

        public Domain.Level Create()
        {
            _container.InstantiatePrefab(_powerCountPrefab).name = _powerCountPrefab.name;
            var entity = new Domain.Level("map", 6);
            _context.Save(entity);
            return entity;
        }
    }
}