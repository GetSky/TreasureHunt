using System;
using System.Collections.Generic;
using Features.Map.Event;

namespace Features.Map
{
    public class Map
    {
        public ICollection<IDomainEvent> Events { get; }
        public string Id { get; }
        private bool _active = true;

        public Action<bool> OnChangedActiveStatus = delegate { };

        public Map(string id)
        {
            Id = id;
            Events = new List<IDomainEvent>();
            Events.Add(new GameStatusChange(_active));
        }

        public void Deactivate()
        {
            _active = false;
            OnChangedActiveStatus.Invoke(_active);
            Events.Add(new GameStatusChange(_active));
        }

        public void Activate()
        {
            _active = true;
            OnChangedActiveStatus.Invoke(_active);
            Events.Add(new GameStatusChange(_active));
        }

        public bool IsActive() => _active;
    }
}