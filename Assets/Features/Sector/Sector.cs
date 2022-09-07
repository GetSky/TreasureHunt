using System;
using System.Numerics;

namespace Features.Sector
{
    public class Sector
    {
        public string Id { get; }
        public bool Treasure { get; }
        private Vector2 Position { get; }

        public Action<string> _onOpened = delegate { };

        public Sector(string id, Vector2 position, bool treasure)
        {
            Id = id;
            Position = position;
            Treasure = treasure;
        }

        public void CalculateSymbol(Sector treasure)
        {
            if (Treasure)
            {
                _onOpened("G");
                return;
            }

            var random = new Random();
            _onOpened.Invoke(random.Next(100) <= 50 ? "?" : DistanceTo(treasure).ToString());
        }

        private int DistanceTo(Sector sector)
        {
            return (int)Math.Floor(Math.Sqrt(
                Math.Pow(Position.X - sector.Position.X, 2) +
                Math.Pow(Position.Y - sector.Position.Y, 2)
            ));
        }
    }
}