using System;
using System.Collections.Generic;
using System.Numerics;
using Features.Sector.Card;
using Features.Sector.Event;

namespace Features.Sector
{
    public class Sector
    {
        public ICollection<IDomainEvent> Events { get; }
        public string Id { get; }
        private Vector2 Position { get; }
        public ICard Card { get; }

        private bool _active = true;

        public Action<ICard> OnOpened = delegate { };
        public Action OnDestroyed = delegate { };
        public Action OnHighlighted = delegate { };
        public Action OnStopHighlighted = delegate { };


        public Sector(string id, Vector2 position, ICard card)
        {
            Events = new List<IDomainEvent>();
            Id = id;
            Position = position;
            Card = card;
        }

        public void Open(Sector treasure)
        {
            if (_active == false) return;

            var domainEvent = Card.Execute(DistanceTo(treasure), this);
            if (domainEvent != null) Events.Add(domainEvent);

            OnOpened.Invoke(Card);
        }

        public void Highlight(Sector sector, int distance)
        {
            if (_active == false) return;

            if (DistanceTo(sector) == distance) OnHighlighted.Invoke();
            else OnStopHighlighted.Invoke();
        }

        public bool IsActive() => _active;

        public void Deactivate() => _active = false;

        public void Activate() => _active = true;

        public void Destroy()
        {
            OnDestroyed();
        }

        private int DistanceTo(Sector sector)
        {
            return (int)Math.Round(
                Math.Sqrt(Math.Pow(Position.X - sector.Position.X, 2) + Math.Pow(Position.Y - sector.Position.Y, 2))
            );
        }
    }
}