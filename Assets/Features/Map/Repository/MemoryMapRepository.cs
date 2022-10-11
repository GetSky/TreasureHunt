using System.Collections.Generic;
using System.Linq;
using Features.Map.Event;
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
            var events = map.Events.ToArray();
            map.Events.Clear();
            foreach (var domainEvent in events) _signalBus.Fire(domainEvent);
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