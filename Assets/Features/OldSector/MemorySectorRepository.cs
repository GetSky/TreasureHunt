using System.Collections.Generic;
using System.Linq;
using Features.OldSector.Card;
using Features.OldSector.Entities;
using Zenject;

namespace Features.OldSector
{
    public class MemorySectorRepository : ISectorRepository, ISectorContext
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Entities.Sector> _sectors = new();

        public MemorySectorRepository(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public Entities.Sector[] FindAll() => _sectors.Values.ToArray();

        public Entities.Sector FindById(string id)
        {
            _sectors.TryGetValue(id, out var entity);
            return entity;
        }

        public Entities.Sector FindTreasure()
        {
            var entity = _sectors.First(sector => sector.Value.Card is TreasureCard);
            return entity.Value;
        }

        public Entities.Sector[] FindInactive()
        {
            return (from s in _sectors where s.Value.IsActive() == false select s.Value).ToArray();
        }

        public void Save(Entities.Sector sector)
        {
            foreach (var domainEvent in sector.Events) _signalBus.Fire((object)domainEvent);
            sector.Events.Clear();

            if (_sectors.ContainsKey(sector.Id)) return;
            _sectors[sector.Id] = sector;
        }

        public void Clear() => _sectors.Clear();

        public void Remove(Entities.Sector sector)
        {
            _sectors.Remove(sector.Id);
        }
    }
}