using Features.Map.Repository;
using Zenject;

namespace Features.Map
{
    public class Factory : PlaceholderFactory<Map>
    {
    }

    public class MapFactory : IFactory<Map>
    {
        private readonly IMapContext _context;

        public MapFactory(IMapContext context)
        {
            _context = context;
        }

        public Map Create()
        {
            var entity = new Map("map");
            _context.Save(entity);

            return entity;
        }
    }
}