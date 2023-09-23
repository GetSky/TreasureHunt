using System.Collections.Generic;
using System.Linq;
using Features.Level.Entity;
using Zenject;

namespace Features.Level
{
    public class MemoryMapRepository : IMapContext, IMapRepository
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Level.Entity.Map> _maps = new();

        public MemoryMapRepository(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Save(Level.Entity.Map map)
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

        public Level.Entity.Map FindCurrent()
        {
            return _maps.Values.First();
        }
    }
}