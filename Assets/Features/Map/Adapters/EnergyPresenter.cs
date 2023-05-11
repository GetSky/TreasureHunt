namespace Features.Map.Adapters
{
    public class EnergyPresenter : IEnergyPresenter, IEnergyPresenterBoundary
    {
        public event IEnergyPresenter.OnUpdatedEnergyHandler OnUpdatedEnergy;

        public void UpdateEnergy(int count) => OnUpdatedEnergy?.Invoke(count);
    }
}