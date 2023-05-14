using Features.Sector.UseCases.CreateSector;
using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class SectorTick : ITickable
    {
        private readonly Gateway _gateway;

        public SectorTick(Gateway gateway)
        {
            _gateway = gateway;
        }

        public void Tick()
        {
            var random = new System.Random();
            if (Input.GetKeyDown(KeyCode.P))
                _gateway.Schedule(new CreateSectorCommand(random.Next(-10, 10), random.Next(-10, 10), "card"));
        }
    }
}