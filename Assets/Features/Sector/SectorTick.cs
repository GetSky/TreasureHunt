using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class SectorTick : ITickable
    {
        private readonly Sector _factory;

        private readonly DiContainer _container;
        private Sector _sector;

        public SectorTick(DiContainer container, Sector factory)
        {
            _container = container;
            _sector = factory;
        }
        
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.P)) _sector = _container.Resolve<Sector>();
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            if (_sector.IsHighlight == false) _sector.Highlight();
            else _sector.Unhighlight();
        }
    }
}