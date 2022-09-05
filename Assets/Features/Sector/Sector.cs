using System.Numerics;

namespace Features.Sector
{
    public class Sector
    {
        public Vector2 Position { get; }
        public bool Treasure { get; }

        public string Id { get; }


        public Sector(string id, Vector2 position, bool treasure)
        {
            Id = id;
            Position = position;
            Treasure = treasure;
        }
    }
}