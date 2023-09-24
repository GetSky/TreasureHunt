using System.Collections.Generic;
using System.Linq;
using Features.Level.Entity;
using Zenject;

namespace Features.Level
{
    public class MemoryLevelRepository : ILevelContext, ILevelRepository
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Entity.Level> _levels = new();

        public MemoryLevelRepository(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Save(Entity.Level level)
        {
            Clear();
            _levels[level.Id] = level;

            var gameStatusEvents = level.Events.ToArray();
            level.Events.Clear();
            foreach (var domainEvent in gameStatusEvents) _signalBus.Fire((object)domainEvent);
        }

        public void Clear()
        {
            _levels.Clear();
        }

        public Entity.Level FindCurrent()
        {
            return _levels.Values.First();
        }
    }
}