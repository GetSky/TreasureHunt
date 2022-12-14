using System.Collections.Generic;

namespace Features.Map
{
    public interface IPowerCountView
    {
        void UpdatePower(int count);
    }

    public class PowerModel
    {
        private readonly List<IPowerCountView> _powerViews = new List<IPowerCountView>();

        public PowerModel(Entity.Map map)
        {
            map.OnTurnUpdated += OnTurnUpdated;
        }

        public void AddView(IPowerCountView view)
        {
            _powerViews.Add(view);
        }

        private void OnTurnUpdated(int powers)
        {
            foreach (var view in _powerViews) view.UpdatePower(powers);
        }
    }
}