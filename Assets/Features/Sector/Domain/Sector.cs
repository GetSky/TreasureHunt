using System;

namespace Features.Sector.Domain
{
    public class Sector
    {
        public event Action OnHighlighted = delegate { };
        public event Action OnStopHighlighted = delegate { };
        public string Id { get; }

        public Sector(string id)
        {
            Id = id;
        }

        public void Highlight()
        {
            OnHighlighted();
        }

        public void Unhighlight()
        {
            OnStopHighlighted();
        }
    }
}