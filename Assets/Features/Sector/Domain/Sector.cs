using System;
using System.Collections.Generic;
using System.Numerics;
using Features.Sector.Domain.Effects;
using Features.Sector.Domain.Events;

namespace Features.Sector.Domain
{
    public class Sector
    {
        public event Action OnHighlighted = delegate { };
        public event Action OnStopHighlighted = delegate { };
        public event Action OnDestroyed = delegate { };
        public event Action<EffectState> OnOpened = delegate { };

        public string Id { get; }
        public Vector2 Position { get; }
        public bool Opened { get; private set; }

        private IEffect Effect { get; }

        private bool _active = true;

        public Sector(string id, Vector2 position, IEffect effect = null)
        {
            Id = id;
            Position = position;
            Effect = effect;
            Opened = false;
        }

        public void Deactivate()
        {
            OnStopHighlighted.Invoke();
            _active = false;
        }

        public void Activate() => _active = true;

        public void Destroy()
        {
            Deactivate();
            OnDestroyed();
        }

        public void HighlightInRadius(Sector center, int radius)
        {
            if (_active == false) return;

            if (MeasureDistanceTo(center) == radius) OnHighlighted.Invoke();
            else OnStopHighlighted.Invoke();
        }

        public int MeasureDistanceTo(Sector sector)
        {
            return (int)Math.Round(
                Math.Sqrt(Math.Pow(Position.X - sector.Position.X, 2) + Math.Pow(Position.Y - sector.Position.Y, 2))
            );
        }

        public IEnumerable<IDomainEvent> OpenWithTreasureIn(Sector sector)
        {
            if (_active == false) return null;

            var domainEvents = new List<IDomainEvent>();
            
            var effectEvent = Effect.Call(this, sector);
            if (effectEvent is null) return domainEvents;
            
            domainEvents.Add(effectEvent);
            OnOpened.Invoke(effectEvent.EffectState);
            
            if (Opened == false) domainEvents.Add(new SectorOpened());
            Opened = true;

            return domainEvents;
        }

        public bool HasTreasure() => Effect is TreasureEffect;
    }
}