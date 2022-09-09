using System;
using System.Numerics;

namespace Features.Sector
{
    public class Sector
    {
        public string Id { get; }
        public bool Treasure { get; }
        private Vector2 Position { get; }

        public Action<string> OnOpened = delegate { };
        public Action OnHighlighted = delegate { };
        public Action OnStopHighlighted = delegate { };

        public Sector(string id, Vector2 position, bool treasure)
        {
            Id = id;
            Position = position;
            Treasure = treasure;
        }

        public int CalculateSymbol(Sector treasure)
        {
            if (Treasure)
            {
                OnOpened("G");
                return 0;
            }

            var distance = DistanceTo(treasure);
            var random = new Random();
            OnOpened.Invoke(random.Next(100) <= 50 ? "?" : distance.ToString());
            return distance;
        }

        public void Highlight(bool isHighlight)
        {
            if (isHighlight) OnHighlighted.Invoke();
            else OnStopHighlighted.Invoke();
        }

        public int DistanceTo(Sector sector)
        {
            return (int)Math.Round(Math.Sqrt(
                Math.Pow(Position.X - sector.Position.X, 2) +
                Math.Pow(Position.Y - sector.Position.Y, 2)
            ));
        }
    }
}