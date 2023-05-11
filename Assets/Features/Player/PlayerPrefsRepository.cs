using Features.Player.Entity;
using UnityEngine;

namespace Features.Player
{
    public class PlayerPrefsRepository : IPlayerContext, IPlayerRepository
    {
        private const string PrefNameId = "local";
        private const string PrefNameCoins = "coins";

        private readonly Factory _factory;

        public PlayerPrefsRepository(Factory factory)
        {
            _factory = factory;
        }

        public void Save(Entity.Player player)
        {
            PlayerPrefs.SetInt(PrefNameCoins, player.CountCoins());
            PlayerPrefs.SetString(PrefNameId, player.Id);
            PlayerPrefs.Save();
        }

        public Entity.Player FindCurrent()
        {
            return _factory.Create(PlayerPrefs.GetString(PrefNameId), PlayerPrefs.GetInt(PrefNameCoins));
        }
    }
}