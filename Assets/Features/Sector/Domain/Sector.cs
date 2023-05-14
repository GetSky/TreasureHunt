using System;
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
        public event Action OnOpened = delegate { };

        public string Id { get; }
        public Vector2 Position { get; }
        private IEffect Effect { get; }

        private bool _active = true;

        public Sector(string id, Vector2 position, IEffect effect = null)
        {
            Id = id;
            Position = position;
            Effect = effect;
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

        public IDomainEvent OpenWithTreasureIn(Sector sector)
        {
            if (_active == false) return null;

            OnOpened.Invoke();
            return Effect.Call(this, sector);
        }

        public bool HasTreasure() => Effect is TreasureEffect;
    }
}