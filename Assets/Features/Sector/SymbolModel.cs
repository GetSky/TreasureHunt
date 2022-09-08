using System.Collections.Generic;
using System.Linq;

namespace Features.Sector
{
    public class SymbolModel
    {
        private readonly Sector _sector;
        private readonly List<ISymbolView> _symbolView = new List<ISymbolView>();

        public SymbolModel(Sector sector)
        {
            _sector = sector;
            _sector._onOpened += OnOpened;
        }

        public void AddView(ISymbolView symbolView)
        {
            _symbolView.Add(symbolView);
        }

        private void OnOpened(string symbol)
        {
            foreach (var view in _symbolView) view.UpdateSymbol(symbol);
            _sector._onOpened -= OnOpened;
        }
    }
}