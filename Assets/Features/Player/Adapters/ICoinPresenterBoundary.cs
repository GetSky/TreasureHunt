namespace Features.Player.Adapters
{
    public interface ICoinPresenterBoundary
    {
        public void UpdateCoin(int count);

        public void SetCoin(int count);
    }
}