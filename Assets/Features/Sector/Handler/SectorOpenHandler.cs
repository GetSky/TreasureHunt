using System;
using Features.Sector.Repository;
using UnityEngine;

namespace Features.Sector.Handler
{
    public class SectorOpenHandler : ISectorOpenHandler
    {
        private readonly ISectorRepository _repository;

        public SectorOpenHandler(ISectorRepository repository)
        {
            _repository = repository;
        }

        public void Invoke(SectorOpenCommand command)
        {
            var sector = _repository.FindById(command.Id);
            if (sector.Treasure) Debug.Log("Win!");
            else
            {
                var treasure = _repository.FindTreasure();
                if (treasure == null) return;

                var distance = Math.Sqrt(
                    Math.Pow(sector.Position.X - treasure.Position.X, 2) +
                    Math.Pow(sector.Position.Y - treasure.Position.Y, 2)
                );

                Debug.Log(distance);
            }
        }
    }
}