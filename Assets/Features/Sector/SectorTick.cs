using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class SectorTick : ITickable
    {
        private readonly SectorFactory _factory;
        
        private Domain.Sector _sector;

        public SectorTick(SectorFactory factory)
        {
            _factory = factory;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.P)) _sector = _factory.Create();
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            if (_sector.IsHighlight == false) _sector.Highlight();
            else _sector.Unhighlight();
        }
    }
}