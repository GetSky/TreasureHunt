namespace Features.Player.Adapters
{
    public interface ICoinPresenter
    {
        public delegate void OnUpdatedCoinsHandler(int count);

        public event OnUpdatedCoinsHandler OnUpdatedCoins;

        public int CurrentCounts();
    }
}