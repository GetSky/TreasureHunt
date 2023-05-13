namespace Features.Sector
{
    public class Sector
    {
        private readonly SectorPresenter _presenter;

        public bool IsHighlight { get; private set; }

        public Sector(SectorPresenter presenter)
        {
            _presenter = presenter;
            IsHighlight = false;
        }

        public void Highlight()
        {
            IsHighlight = true;
            _presenter.ChangeHighlight(IsHighlight);
        }

        public void Unhighlight()
        {
            IsHighlight = false;
            _presenter.ChangeHighlight(IsHighlight);
        }
    }
}