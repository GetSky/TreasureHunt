using System;

namespace Features.Sector.Adapters
{
    public class SectorPresenter
    {
        private readonly Domain.Sector _sector;

        public event Action<bool> OnChangedHighlight;

        public SectorPresenter(Domain.Sector sector)
        {
            _sector = sector;

            _sector.OnHighlighted += () => OnChangedHighlight?.Invoke(true);
            _sector.OnStopHighlighted += () => OnChangedHighlight?.Invoke(false);
        }
    }
}