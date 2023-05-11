namespace Features.Map.Adapters
{
    public interface IEnergyPresenter
    {
        public delegate void OnUpdatedEnergyHandler(int count);

        public event OnUpdatedEnergyHandler OnUpdatedEnergy;
    }
}