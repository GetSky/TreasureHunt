using System.Collections.Generic;

namespace Features.Player
{
    public interface ICoinsView
    {
        void UpdateCoins(int count);
    }

    public class CoinsModel
    {
        private readonly Entity.Player _player;
        private readonly List<ICoinsView> _coinsViews = new List<ICoinsView>();

        public CoinsModel(Entity.Player player)
        {
            _player = player;
            player.OnCoinsUpdate += OnCoinsUpdate;
        }

        public void AddView(ICoinsView view)
        {
            _coinsViews.Add(view);
            view.UpdateCoins(_player.Coins);
        }

        private void OnCoinsUpdate(int count)
        {
            foreach (var view in _coinsViews) view.UpdateCoins(count);
        }
    }
}