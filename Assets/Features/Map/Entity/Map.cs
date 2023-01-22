using System;
using System.Collections.Generic;
using Features.Map.Event;
using Features.Map.Handler;

namespace Features.Map.Entity
{
    public class Map
    {
        public ICollection<GameStatusChanged> GameStatusChangeEvents { get; }
        public ICollection<MapUnloaded> UnloadEvents { get; }
        public ICollection<MapLoaded> LoadEvents { get; }
        public string Id { get; }
        private readonly Energy _energy;
        private bool _active = true;

        public Action<bool> OnChangedActiveStatus = delegate { };
        public Action<int> OnEnergyUpdated = delegate { };

        public Map(string id, int energy)
        {
            Id = id;
            _energy = new Energy(energy);
            GameStatusChangeEvents = new List<GameStatusChanged>();
            GameStatusChangeEvents.Add(new GameStatusChanged(_active));
            UnloadEvents = new List<MapUnloaded>();
            LoadEvents = new List<MapLoaded>();
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
            _energy.Reset();
            LoadEvents.Add(new MapLoaded());
            OnEnergyUpdated.Invoke(_energy.Count());
        }

        public void DecreaseTurnCount()
        {
            if (_energy.Decrease() == false) return;
            if (_energy.IsRanOut()) Deactivate();
            OnEnergyUpdated.Invoke(_energy.Count());
        }

        public void RaiseTurnCount(RaiseTurnCountCommand command)
        {
            _energy.BoostBy(command.Count);
            OnEnergyUpdated.Invoke(_energy.Count());
        }

        public void UnloadMap()
        {
            if (_active) return;

            UnloadEvents.Add(new MapUnloaded());
        }
    }
}