namespace Features.Level.Adapters
{
    public interface IEnergyPresenter
    {
        public delegate void OnUpdatedEnergyHandler(int count);

        public event OnUpdatedEnergyHandler OnUpdatedEnergy;
    }
}