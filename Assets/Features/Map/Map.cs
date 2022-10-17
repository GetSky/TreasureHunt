using System;
using System.Collections.Generic;
using Features.Map.Event;

namespace Features.Map
{
    public class Map
    {
        public ICollection<GameStatusChange> GameStatusChangeEvents { get; }
        public ICollection<ResetMap> ResetEvents { get; }
        public string Id { get; }
        private bool _active = true;

        public Action<bool> OnChangedActiveStatus = delegate { };

        public Map(string id)
        {
            Id = id;
            GameStatusChangeEvents = new List<GameStatusChange>();
            GameStatusChangeEvents.Add(new GameStatusChange(_active));
            ResetEvents = new List<ResetMap>();
        }

        public void Deactivate()
        {
            _active = false;
            OnChangedActiveStatus.Invoke(_active);
            GameStatusChangeEvents.Add(new GameStatusChange(_active));
        }

        public void Activate()
        {
            _active = true;
            OnChangedActiveStatus.Invoke(_active);
            GameStatusChangeEvents.Add(new GameStatusChange(_active));
        }

        public void ResetMap()
        {
            ResetEvents.Add(new ResetMap());
        }
    }
}