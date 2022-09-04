using System.Numerics;

namespace Features.Sector
{
    public class Sector
    {
        private Vector2 _position;
        private readonly bool _treasure;

        public string Id { get; }


        public Sector( string id, Vector2 position, bool treasure)
        {
            Id = id;
            _position = position;
            _treasure = treasure;
        }
    }
}