using System.Collections.Generic;

namespace Features.EndGameMenu
{
    public class EndGameMenuModel
    {
        private readonly Map.Map _map;
        private readonly List<IEndGameMenuView> _mapViews = new List<IEndGameMenuView>();

        public EndGameMenuModel(Map.Map map)
        {
            _map = map;
            _map.OnChangedActiveStatus += OnChangedActiveStatus;
        }

        public void AddView(IEndGameMenuView symbolView)
        {
            _mapViews.Add(symbolView);
        }

        private void OnChangedActiveStatus(bool active)
        {
            foreach (var view in _mapViews) view.SetVisible(!active);
        }
    }
}