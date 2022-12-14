using Features.Map.Repository;
using UnityEngine;
using Zenject;

namespace Features.Map
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

        public Entity.Map Create()
        {
            var obj = _container.InstantiatePrefabForComponent<IPowerCountView>(_powerCountPrefab);

            var entity = new Entity.Map("map", 6);
            _context.Save(entity);

            var model = new PowerModel(entity);
            model.AddView(obj);

            return entity;
        }
    }
}