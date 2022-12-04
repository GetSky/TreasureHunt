using System;
using System.Collections.Generic;
using Features.Map.Event;

namespace Features.Map
{
    public class Map
    {
        public ICollection<GameStatusChanged> GameStatusChangeEvents { get; }
        public ICollection<MapUnloaded> UnloadEvents { get; }
        public ICollection<MapLoaded> LoadEvents { get; }
        public string Id { get; }
        private TurnCounter _turnCounter;
        private bool _active = true;

        public Action<bool> OnChangedActiveStatus = delegate { };

        public Map(string id, int turnsCount)
        {
            Id = id;
            _turnCounter = new TurnCounter(turnsCount);
            GameStatusChangeEvents = new List<GameStatusChanged>();
            GameStatusChangeEvents.Add(new GameStatusChanged(_active));
            UnloadEvents = new List<MapUnloaded>();
            LoadEvents = new List<MapLoaded>();
            LoadEvents.Add(new MapLoaded());
        }

        public void Deactivate()
        {
            _active = false;
            OnChangedActiveStatus.Invoke(_active);
            GameStatusChangeEvents.Add(new GameStatusChanged(_active));
        }

        public void Activate()
        {
            _active = true;
            OnChangedActiveStatus.Invoke(_active);
            GameStatusChangeEvents.Add(new GameStatusChanged(_active));
            _turnCounter.Reset();
        }

        public void DecreaseTurnCount()
        {
            if (_turnCounter.Decrease() == false) return;
            if (_turnCounter.RanOut()) Deactivate();
        }

        public void UnloadMap()
        {
            if (_active) return;

            UnloadEvents.Add(new MapUnloaded());
        }
    }
}