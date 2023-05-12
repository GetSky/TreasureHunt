using Features.Sector.View.State;

namespace Features.OldSector.Adapters
{
    public interface ISymbolView
    {
        public void UpdateSymbol(State state, int value);

        public void DestroyView();
    }
}