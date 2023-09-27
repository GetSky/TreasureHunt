using System.Collections.Generic;
using System.Linq;
using Features.Level.Domain;
using Zenject;

namespace Features.Level
{
    public class MemoryLevelRepository : ILevelContext, ILevelRepository
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Domain.Level> _levels = new();

        public MemoryLevelRepository(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Save(Domain.Level level)
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

        public Domain.Level FindCurrent()
        {
            return _levels.Values.First();
        }
    }
}