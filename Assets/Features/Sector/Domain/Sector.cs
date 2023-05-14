using Features.Sector.Adapters;

namespace Features.Sector.Domain
{
    public class Sector
    {
        public string Id { get; }
        private readonly SectorPresenter _presenter;

        public bool IsHighlight { get; private set; }

        public Sector(string id, SectorPresenter presenter)
        {
            Id = id;
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