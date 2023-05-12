using Features.Sector.View.State;

namespace Features.Sector.Adapters
{
    public interface ISymbolView
    {
        public void UpdateSymbol(State state, int value);

        public void DestroyView();
    }
}