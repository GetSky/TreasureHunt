using System.Collections.Generic;
using System.Linq;

namespace Features.Map.Repository
{
    public class MemoryMapRepository : IMapFlasher, IMapRepository
    {
        private readonly Dictionary<string, Map> _maps = new Dictionary<string, Map>();
        
        public void Save(Map map)
        {
            Clear();
            _maps[map.Id] = map;
        }

        public void Clear()
        {
            _maps.Clear();
        }

        public Map FindActive()
        {
            var entity = _maps.FirstOrDefault(map => map.Value.IsActive());
            return entity.Value;
        }
    }
}