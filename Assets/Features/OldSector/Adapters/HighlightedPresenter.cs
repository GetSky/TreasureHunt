namespace Features.OldSector.Adapters
{
    public class HighlightedPresenter
    {
        private readonly IHighlightedView _view;

        public HighlightedPresenter(OldSector.Entities.Sector sector, IHighlightedView view)
        {
            _view = view;

            sector.OnHighlighted += OnHighlighted;
            sector.OnStopHighlighted += OnStopHighlighted;
        }

        private void OnHighlighted() => _view.Highlight();

        private void OnStopHighlighted() => _view.StopHighlight();
    }
}