namespace Features.Sector
{
    public class SymbolModel
    {
        private readonly Sector _sector;
        private readonly ISymbolView _symbolView;

        public SymbolModel(Sector sector, ISymbolView symbolView)
        {
            _sector = sector;
            _symbolView = symbolView;
            _sector._onOpened += OnOpened;
        }

        private void OnOpened(string symbol)
        {
            _symbolView.UpdateSymbol(symbol);
            _sector._onOpened -= OnOpened;
        }
    }
}