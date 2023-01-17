using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Features.Player.Repository
{
    public class PlayerPrefsRepository : IPlayerContext, IPlayerRepository
    {
        private readonly Factory _factory;
        private readonly Dictionary<string, Entity.Player> _players = new Dictionary<string, Entity.Player>();

        public PlayerPrefsRepository(Factory factory)
        {
            _factory = factory;
        }

        public void Save(Entity.Player player)
        {
            _players[player.Id] = player;

            PlayerPrefs.SetInt("coins", player.Coins);
            PlayerPrefs.SetString("id", player.Id);
            PlayerPrefs.Save();
        }

        public Entity.Player FindCurrent()
        {
            if (_players.Count > 0) return _players.Values.First();

            var id = PlayerPrefs.GetString("id", "local");
            var coins = PlayerPrefs.GetInt("coins");

            return _factory.Create(id, coins);
        }
    }
}