namespace Features.EndGameMenu.Adapters
{
    public interface IEndGamePresenter
    {
        public delegate void OnChangedStatusHandler(bool isActive);

        public event OnChangedStatusHandler OnChangedStatus;

        public void ReloadMap();

        public void ChangeActiveStatus(bool isActive);
    }
}