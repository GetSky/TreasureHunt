using System;
using System.Collections.Generic;
using Features.Map.Event;

namespace Features.Map
{
    public class Map
    {
        public ICollection<GameStatusChanged> GameStatusChangeEvents { get; }
        public ICollection<MapReloaded> ResetEvents { get; }
        public string Id { get; }
        private bool _active = true;

        public Action<bool> OnChangedActiveStatus = delegate { };

        public Map(string id)
        {
            Id = id;
            GameStatusChangeEvents = new List<GameStatusChanged>();
            GameStatusChangeEvents.Add(new GameStatusChanged(_active));
            ResetEvents = new List<MapReloaded>();
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
        }

        public void ReloadMap()
        {
            ResetEvents.Add(new MapReloaded());
        }
    }
}