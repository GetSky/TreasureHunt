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

        public Map FindCurrent()
        {
            return _maps.Values.First();
        }
    }
}