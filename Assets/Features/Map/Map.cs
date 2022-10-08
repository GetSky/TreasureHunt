﻿namespace Features.Map
{
    public class Map
    {
        public string Id { get; }

        private bool _active = true;

        public Map(string id)
        {
            Id = id;
        }

        public void Deactivate() => _active = false;
        public void Activate() => _active = true;
        public bool IsActive() => _active;
    }
}