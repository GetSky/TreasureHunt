using System.Numerics;

namespace Features.Sector
{
    public class Sector
    {
        private Vector2 _position;
        private readonly bool _treasure;

        public Sector(Vector2 position, bool treasure)
        {
            _position = position;
            _treasure = treasure;
        }
    }
}