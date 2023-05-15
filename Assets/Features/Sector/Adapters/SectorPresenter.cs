using System;
using Features.Sector.Domain;

namespace Features.Sector.Adapters
{
    public class SectorPresenter
    {
        private readonly Domain.Sector _sector;

        public event Action<bool> OnChangedHighlight;
        public event Action OnDestroyed;
        public event Action<EffectStateType, int> OnOpened;

        public SectorPresenter(Domain.Sector sector)
        {
            _sector = sector;

            _sector.OnHighlighted += () => OnChangedHighlight?.Invoke(true);
            _sector.OnStopHighlighted += () => OnChangedHighlight?.Invoke(false);
            _sector.OnDestroyed += () => OnDestroyed?.Invoke();
            _sector.OnOpened += SectorOnOnOpened;
        }

        private void SectorOnOnOpened(EffectState effect)
        {
            OnOpened?.Invoke(effect.Type, effect.Value);
            _sector.OnOpened -= SectorOnOnOpened;
        }
    }
}