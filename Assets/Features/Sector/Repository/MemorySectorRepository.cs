using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Features.Sector.Repository
{
    public class MemorySectorRepository : ISectorRepository, ISectorFlasher
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Sector> _sectors = new Dictionary<string, Sector>();

        public MemorySectorRepository(SignalBus _signalBus)
        {
            this._signalBus = _signalBus;
        }

        public Sector[] FindAll() => _sectors.Values.ToArray();

        public Sector FindById(string id)
        {
            _sectors.TryGetValue(id, out var entity);
            return entity;
        }

        public Sector FindTreasure()
        {
            var entity = _sectors.First(sector => sector.Value.Card.Type() == CardType.Treasure);
            return entity.Value;
        }

        public void Save(Sector sector)
        {
            foreach (var domainEvent in sector.Events) _signalBus.Fire(domainEvent);
            sector.Events.Clear();

            if (_sectors.ContainsKey(sector.Id)) return;
            _sectors[sector.Id] = sector;
        }

        public void Clear() => _sectors.Clear();
    }
}