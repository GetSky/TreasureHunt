using System;

namespace Features.Map
{
    public class Map
    {
        public string Id { get; }

        private bool _active = true;
        public Action<bool> OnChangedActiveStatus = delegate { };

        public Map(string id)
        {
            Id = id;
        }

        public void Deactivate()
        {
            _active = false;
            OnChangedActiveStatus.Invoke(_active);
        }

        public void Activate()
        {
            _active = true;
            OnChangedActiveStatus.Invoke(_active);
        }

        public bool IsActive() => _active;
    }
}