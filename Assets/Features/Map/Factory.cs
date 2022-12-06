using Features.Map.Repository;
using Zenject;

namespace Features.Map
{
    public class Factory : PlaceholderFactory<Entity.Map>
    {
    }

    public class MapFactory : IFactory<Entity.Map>
    {
        private readonly IMapContext _context;

        public MapFactory(IMapContext context)
        {
            _context = context;
        }

        public Entity.Map Create()
        {
            var entity = new Entity.Map("map", 6);
            _context.Save(entity);

            return entity;
        }
    }
}