using System.Collections.Generic;
using System.Linq;

namespace Features.Player.Repository
{
    public class MemoryPlayerRepository : IPlayerContext, IPlayerRepository
    {
        private readonly Dictionary<string, Entity.Player> _players = new Dictionary<string, Entity.Player>();

        public void Save(Entity.Player player)
        {
            _players[player.Id] = player;
        }

        public Entity.Player FindCurrent()
        {
            return _players.Values.First();
        }
    }
}