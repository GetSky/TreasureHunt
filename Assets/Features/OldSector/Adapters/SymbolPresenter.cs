using Features.OldSector.Card;
using Features.Sector.View.State;

namespace Features.OldSector.Adapters
{
    public class SymbolPresenter
    {
        private readonly OldSector.Entities.Sector _sector;
        private readonly ISymbolView _view;

        public SymbolPresenter(OldSector.Entities.Sector sector, ISymbolView symbolView)
        {
            _sector = sector;
            _view = symbolView;
            _sector.OnOpened += OnOpened;
            _sector.OnDestroyed += OnDestroyed;
        }

        private void OnDestroyed()
        {
            _view.DestroyView();

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

            _view.UpdateSymbol(state, card.Value());

            _sector.OnOpened -= OnOpened;
        }
    }
}