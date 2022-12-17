using System.Collections.Generic;

namespace Features.Map
{
    public interface IEnergyView
    {
        void UpdateEnergy(int count);
    }

    public class EnergyModel
    {
        private readonly List<IEnergyView> _energyViews = new List<IEnergyView>();

        public EnergyModel(Entity.Map map)
        {
            map.OnEnergyUpdated += OnEnergyUpdated;
        }

        public void AddView(IEnergyView view)
        {
            _energyViews.Add(view);
        }

        private void OnEnergyUpdated(int powers)
        {
            foreach (var view in _energyViews) view.UpdateEnergy(powers);
        }
    }
}