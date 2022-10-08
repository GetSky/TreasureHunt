using System.Collections.Generic;

namespace Features.Map
{
    public class MapModel
    {
        private readonly Map _map;
        private readonly List<IMapView> _mapViews = new List<IMapView>();

        public MapModel(Map map)
        {
            _map = map;
            _map.OnChangedActiveStatus += OnChangedActiveStatus;
        }

        public void AddView(IMapView symbolView)
        {
            _mapViews.Add(symbolView);
        }

        private void OnChangedActiveStatus(bool active)
        {
            foreach (var view in _mapViews) view.SetVisible(!active);
        }
    }
}