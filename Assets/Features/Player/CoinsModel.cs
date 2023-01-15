using System.Collections.Generic;

namespace Features.Player
{
    public interface ICoinsView
    {
        void UpdateCoins(int count);
    }

    public class CoinsModel
    {
        private readonly List<ICoinsView> _coinsViews = new List<ICoinsView>();

        public CoinsModel(Entity.Player player)
        {
            player.OnCoinsUpdate += OnCoinsUpdate;
        }

        public void AddView(ICoinsView view)
        {
            _coinsViews.Add(view);
        }

        private void OnCoinsUpdate(int count)
        {
            foreach (var view in _coinsViews) view.UpdateCoins(count);
        }
    }
}