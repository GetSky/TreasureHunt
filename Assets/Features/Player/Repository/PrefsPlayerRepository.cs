using UnityEngine;

namespace Features.Player.Repository
{
    public class PrefsPlayerRepository : IPlayerContext, IPlayerRepository
    {
        private readonly Factory _factory;

        public PrefsPlayerRepository(Factory factory)
        {
            _factory = factory;
        }

        public void Save(Entity.Player player)
        {
            PlayerPrefs.SetInt("coins", player.Coins);
            PlayerPrefs.SetString("id", player.Id);
            PlayerPrefs.Save();
        }

        public Entity.Player FindCurrent()
        {
            var id = PlayerPrefs.GetString("id", "local");
            var coins = PlayerPrefs.GetInt("coins");
            return _factory.Create(id, coins);
        }
    }
}