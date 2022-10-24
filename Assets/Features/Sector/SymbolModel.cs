using System.Collections.Generic;
using Features.Sector.Card;

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
            var symbol = card switch
            {
                NoneCard _ => "-",
                TreasureCard _ => "X",
                DistanceCard _ => card.Value() == -1 ? "?" : card.Value().ToString(),
                _ => ""
            };

            foreach (var view in _symbolView) view.UpdateSymbol(symbol);

            _sector.OnOpened -= OnOpened;
        }
    }
}