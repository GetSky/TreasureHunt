using System.Collections.Generic;
using System.Linq;
using Features.Map.Entity;
using Zenject;

namespace Features.Map
{
    public class MemoryMapRepository : IMapContext, IMapRepository
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Entity.Map> _maps = new();

        public MemoryMapRepository(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Save(Entity.Map map)
        {
            Clear();
            _maps[map.Id] = map;

            var gameStatusEvents = map.GameStatusChangeEvents.ToArray();
            map.GameStatusChangeEvents.Clear();
            foreach (var domainEvent in gameStatusEvents) _signalBus.Fire(domainEvent);

            var unloadEvents = map.UnloadEvents.ToArray();
            map.UnloadEvents.Clear();
            foreach (var domainEvent in unloadEvents) _signalBus.Fire(domainEvent);
            
            var loadEvents = map.LoadEvents.ToArray();
            map.LoadEvents.Clear();
            foreach (var domainEvent in loadEvents) _signalBus.Fire(domainEvent);
        }

        public void Clear()
        {
            _maps.Clear();
        }

        public Entity.Map FindCurrent()
        {
            return _maps.Values.First();
        }
    }
}