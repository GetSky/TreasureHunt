using System.Collections.Generic;

namespace Features.Sector
{
    public class HighlightedModel
    {
        private readonly Entities.Sector _sector;
        private readonly List<IHighlightedView> _symbolView = new List<IHighlightedView>();

        public HighlightedModel(Entities.Sector sector)
        {
            _sector = sector;
            _sector.OnHighlighted += OnHighlighted;
            _sector.OnStopHighlighted += OnStopHighlighted;
        }

        public void AddView(IHighlightedView view)
        {
            _symbolView.Add(view);
        }

        private void OnHighlighted()
        {
            foreach (var view in _symbolView) view.Highlight();
        }

        private void OnStopHighlighted()
        {
            foreach (var view in _symbolView) view.StopHighlight();
        }
    }
}