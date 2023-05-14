using Features.Sector.Domain;
using Features.Sector.UseCases.CreateSector;
using UnityEngine;
using Zenject;

namespace Features.Sector
{
    public class SectorTick : ITickable
    {
        private readonly Gateway _gateway;
        private readonly ISectorRepository _repository;

        public SectorTick(Gateway gateway, ISectorRepository repository)
        {
            _gateway = gateway;
            _repository = repository;
        }

        public void Tick()
        {
            var random = new System.Random();
            if (Input.GetKeyDown(KeyCode.P))
                _gateway.Schedule(new CreateSectorCommand(random.Next(0, 10), random.Next(0, 10), "card"));
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            var sector = _repository.FindById("333");
            if (sector is null) return;

            if (sector.IsHighlight) sector.Unhighlight();
            else sector.Highlight();
        }
    }
}