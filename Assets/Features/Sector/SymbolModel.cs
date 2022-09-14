using System;
using System.Collections.Generic;

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
        }

        public void AddView(ISymbolView symbolView)
        {
            _symbolView.Add(symbolView);
        }

        private void OnOpened(ICard card)
        {
            var symbol = card.Type() switch
            {
                CardType.None => "-",
                CardType.Treasure => "X",
                CardType.Distance => card.Value() == -1 ? "?" : card.Value().ToString(),
                _ => ""
            };

            foreach (var view in _symbolView) view.UpdateSymbol(symbol);
            
            _sector.OnOpened -= OnOpened;
        }
    }
}