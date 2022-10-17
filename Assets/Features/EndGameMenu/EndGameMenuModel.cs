using System.Collections.Generic;

namespace Features.EndGameMenu
{
    public class EndGameMenuModel
    {
        private readonly List<IEndGameMenuView> _mapViews = new List<IEndGameMenuView>();

        public void AddView(IEndGameMenuView symbolView)
        {
            _mapViews.Add(symbolView);
        }

        public void ChangeActiveStatus(bool active)
        {
            foreach (var view in _mapViews) view.SetVisible(active);
        }
    }
}