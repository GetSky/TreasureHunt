﻿using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Features.Map.Repository
{
    public class MemoryMapRepository : IMapContext, IMapRepository
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

        public Map FindCurrent()
        {
            return _maps.Values.First();
        }
    }
}