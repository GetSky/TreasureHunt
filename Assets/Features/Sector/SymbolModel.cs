using System.Collections.Generic;
using Features.Map.Entity;
using Features.Sector.Card;
using Features.Sector.View.State;

namespace Features.Sector
{
    public class SymbolModel
    {
        private readonly Sector _sector;
        private readonly List<ISymbolView> _symbolView = new List<ISymbolView>();

        public SymbolModel(Sector sector)
        {
            _sector = sector;
            _sector.OnOpened += OnOpened;
            _sector.OnDestroyed += OnDestroyed;
        }

        public void AddView(ISymbolView symbolView)
        {
            _symbolView.Add(symbolView);
        }

        private void OnDestroyed()
        {
            foreach (var view in _symbolView) view.DestroyView();
            _sector.OnOpened -= OnOpened;
            _sector.OnDestroyed -= OnDestroyed;
        }

        private void OnOpened(ICard card)
        {
            var state = card switch
            {
                NoneCard _ => State.Empty,
                TreasureCard _ => State.Treasure,
                CoinCard _ => State.Coin,
                EnergyCard _ => State.Energy,
                DistanceCard _ => card.Value() == -1 ? State.TooFar : State.Distance,
                _ => State.Empty
            };

            foreach (var view in _symbolView) view.UpdateSymbol(state, card.Value());

            _sector.OnOpened -= OnOpened;
        }
    }
}