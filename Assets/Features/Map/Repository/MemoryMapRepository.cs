using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Features.Map.Repository
{
    public class MemoryMapRepository : IMapFlasher, IMapRepository
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Map> _maps = new Dictionary<string, Map>();

        public MemoryMapRepository(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Save(Map map)
        {
            Clear();
            _maps[map.Id] = map;

            foreach (var domainEvent in map.Events) _signalBus.Fire(domainEvent);
            map.Events.Clear();
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