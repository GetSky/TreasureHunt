using System;
using Features.Sector.Domain;
using Features.Sector.Domain.Effects;
using Features.Sector.View.State;

namespace Features.Sector.Adapters
{
    public class SectorPresenter
    {
        private readonly Domain.Sector _sector;

        public event Action<bool> OnChangedHighlight;
        public event Action OnDestroyed;
        public event Action<State, int> OnOpened;

        public SectorPresenter(Domain.Sector sector)
        {
            _sector = sector;

            _sector.OnHighlighted += () => OnChangedHighlight?.Invoke(true);
            _sector.OnStopHighlighted += () => OnChangedHighlight?.Invoke(false);
            _sector.OnDestroyed += () => OnDestroyed?.Invoke();
            _sector.OnOpened += SectorOnOnOpened;
        }

        private void SectorOnOnOpened(IEffect effect)
        {
            var value = 0;
            var state = effect switch
            {
                NoneEffect _ => State.Empty,
                TreasureEffect _ => State.Treasure,
                CoinEffect _ => State.Coin,
                EnergyEffect _ => State.Energy,
                DisplayDistanceEffect d => (value = d.Value()) == 0 ? State.TooFar : State.Distance,
                _ => State.Empty
            };
            
            OnOpened?.Invoke(state, value);


            _sector.OnOpened -= SectorOnOnOpened;
        }
    }
}