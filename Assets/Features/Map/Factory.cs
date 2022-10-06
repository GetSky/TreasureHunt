using Features.Map.Repository;
using Zenject;

namespace Features.Map
{
    public class Factory : PlaceholderFactory<Map>
    {
    }

    public class MapFactory : IFactory<Map>
    {
        private readonly IMapFlasher _mapFlasher;

        public MapFactory(IMapFlasher mapFlasher)
        {
            _mapFlasher = mapFlasher;
        }

        public Map Create()
        {
            var entity = new Map("map");
            _mapFlasher.Save(entity);

            return entity;
        }
    }
}