using System;
using System.Collections.Generic;
using System.Numerics;
using Features.Sector.Card;
using Features.Sector.Event;

namespace Features.Sector.Entities
{
    public enum State
    {
        Quiet,
        Open,
        Highlight,
        Destroy
    }

    public class Sector
    {
        public ICollection<IDomainEvent> Events { get; }
        public string Id { get; }
        public Vector2 Position { get; }
        public ICard Card { get; }
        public State State { get; }

        private bool _active = true;

        public Action<ICard> OnOpened = delegate { };
        public Action OnDestroyed = delegate { };
        public Action OnHighlighted = delegate { };
        public Action OnStopHighlighted = delegate { };


        public Sector(string id, Vector2 position, ICard card, State state = State.Quiet)
        {
            Events = new List<IDomainEvent>();
            Id = id;
            Position = position;
            Card = card;
            State = state;
        }

        public void OpenWithTreasureIn(Sector sector)
        {
            Events.Add(new SectorOpen());
            if (_active == false) return;

            var domainEvent = Card.Execute(MeasureDistanceTo(sector), this);
            if (domainEvent != null) Events.Add(domainEvent);

            OnOpened.Invoke(Card);
        }

        public void HighlightInRadius(Sector center, int radius)
        {
            if (_active == false) return;

            if (MeasureDistanceTo(center) == radius) OnHighlighted.Invoke();
            else OnStopHighlighted.Invoke();
        }

        public bool IsActive() => _active;

        public void Deactivate() => _active = false;

        public void Activate() => _active = true;

        public void Destroy() => OnDestroyed();

        private int MeasureDistanceTo(Sector sector)
        {
            return (int)Math.Round(
                Math.Sqrt(Math.Pow(Position.X - sector.Position.X, 2) + Math.Pow(Position.Y - sector.Position.Y, 2))
            );
        }
    }
}