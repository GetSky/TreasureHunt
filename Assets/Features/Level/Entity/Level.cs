using System.Collections.Generic;
using Features.Level.Commands;
using Features.Level.Event;

namespace Features.Level.Entity
{
    public class Level
    {
        public ICollection<IDomainEvent> Events { get; }
        public string Id { get; }
        private readonly Energy _energy;
        private bool _active = true;

        public Level(string id, int energy)
        {
            Id = id;
            _energy = new Energy(energy);
            Events = new List<IDomainEvent>();
            Events.Add(new GameStatusChanged(_active));
        }

        public void Deactivate()
        {
            _active = false;
            Events.Add(new GameStatusChanged(_active));
        }

        public void Activate()
        {
            _active = true;
            Events.Add(new GameStatusChanged(_active));
            _energy.Reset();
            Events.Add(new LevelLoaded());
        }

        public int DecreaseTurnCount()
        {
            if (_energy.Decrease() == false) return _energy.Count();
            if (_energy.IsRanOut()) Deactivate();
            return _energy.Count();
        }

        public int RaiseTurnCount(RaiseTurnCountCommand command)
        {
            _energy.BoostBy(command.Count);
            return _energy.Count();
        }

        public void UnloadLevel()
        {
            if (_active) return;
            Events.Add(new LevelUnloaded());
        }
    }
}