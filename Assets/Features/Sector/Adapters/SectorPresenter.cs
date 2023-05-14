using System;

namespace Features.Sector.Adapters
{
    public class SectorPresenter
    {
        public event Action<bool> OnChangedHighlight;

        public void ChangeHighlight(bool isHighlight)
        {
            OnChangedHighlight?.Invoke(isHighlight);
        }
    }
}