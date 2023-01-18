using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Features.Player.Repository
{
    public class PlayerPrefsRepository : IPlayerContext, IPlayerRepository
    {
        private const string PrefNameId = "local";
        private const string PrefNameCoins = "coins";

        private readonly Factory _factory;
        private readonly Dictionary<string, Entity.Player> _players = new Dictionary<string, Entity.Player>();

        public PlayerPrefsRepository(Factory factory)
        {
            _factory = factory;
        }

        public void Save(Entity.Player player)
        {
            _players[player.Id] = player;

            PlayerPrefs.SetInt(PrefNameCoins, player.Coins);
            PlayerPrefs.SetString(PrefNameId, player.Id);
            PlayerPrefs.Save();
        }

        public Entity.Player FindCurrent()
        {
            return _players.Count > 0
                ? _players.Values.First()
                : _factory.Create(PlayerPrefs.GetString(PrefNameId, "local"), PlayerPrefs.GetInt(PrefNameCoins));
        }
    }
}