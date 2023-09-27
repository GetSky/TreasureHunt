using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Features.Sector.Domain.Effects;
using Features.Sector.Domain.Events;
using Vector2 = System.Numerics.Vector2;

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

        public IDomainEvent Click()
        {
            if (_active == false || Opened) return null;
            return new SectorClicked(Position.X, Position.Y);
        }

        public IEnumerable<IDomainEvent> RandomOpenFrom(IEnumerable<Sector> sectors, Sector treasure)
        {
            var random = new Random();
            var closeSectors = sectors.Where(sector => sector.Opened == false).OrderBy(x => random.Next());

            var events = new List<IDomainEvent>();
            var i = 0;
            foreach (var sector in closeSectors)
            {
                i++;

                var domainEvents = sector.OpenWithTreasureIn(treasure);
                if (domainEvents is null) continue;
                events.AddRange(domainEvents);

                if (i == 2) break;
            }

            return events;
        }

        public IEnumerable OpenInRadius(IEnumerable<Sector> sectors, Sector treasure, int distance)
        {
            var closeSectors = sectors.Where(sector => sector.Opened == false).ToArray();
            var events = new List<IDomainEvent>();

            foreach (var sector in closeSectors)
            {
                if (MeasureDistanceTo(sector) <= distance) events.AddRange(sector.OpenWithTreasureIn(treasure));
            }

            return events;
        }

        public void HighlightSectorWithEffects(IEnumerable<Sector> sectors, int distance)
        {
            foreach (var sector in sectors)
            {
                if (MeasureDistanceTo(sector) <= distance && sector.HasEffect()) sector.OnHighlighted.Invoke();
                else sector.OnStopHighlighted.Invoke();
            }
        }

        public void HighlightInRadius(Sector center, int radius)
        {
            if (_active == false) return;

            if (MeasureDistanceTo(center) == radius) OnHighlighted.Invoke();
            else OnStopHighlighted.Invoke();
        }

        public void HighlightInDirection(Sector sector, int angle)
        {
            if (_active == false) return;

            if (FindAngleBetween(angle, sector.MeasureDirectionTo(this)) <= 30) OnHighlighted.Invoke();
            else OnStopHighlighted.Invoke();
        }

        public int MeasureDistanceTo(Sector sector)
        {
            return (int)Math.Round(
                Math.Sqrt(Math.Pow(Position.X - sector.Position.X, 2) + Math.Pow(Position.Y - sector.Position.Y, 2))
            );
        }

        public float MeasureDirectionTo(Sector sector)
        {
            var angle = Math.Atan2(sector.Position.Y - Position.Y, sector.Position.X - Position.X) * 180 / Math.PI;
            return (float)(angle < 0 ? angle + 360 : angle);
        }

        public IEnumerable<IDomainEvent> OpenWithTreasureIn(Sector sector)
        {
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

        public bool HasEffect() => Effect is not EmptyEffect;

        private static float FindAngleBetween(float first, float second)
        {
            var angleToDirection = first - second;
            var directionToAngle = second - first;

            var start = first > second ? angleToDirection : directionToAngle;
            var end = (first > second ? directionToAngle : angleToDirection) + 360;

            return start > end ? end : start;
        }
    }
}