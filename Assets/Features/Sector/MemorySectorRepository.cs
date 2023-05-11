using System.Collections.Generic;
using System.Linq;
using Features.Sector.Card;
using Features.Sector.Commands;
using Features.Sector.Entities;
using Features.Sector.Event;
using Features.Sector.Repository;
using Zenject;

namespace Features.Sector
{
    public class MemorySectorRepository : ISectorRepository, ISectorContext
    {
        private readonly SignalBus _signalBus;
        private readonly Dictionary<string, Entities.Sector> _sectors = new Dictionary<string, Entities.Sector>();

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
            var events = sector.Events.ToArray();
            sector.Events.Clear();

            foreach (var domainEvent in events)
            {
                switch (domainEvent)
                {
                    case SectorOpen @event:
                        _signalBus.Fire(@event);
                        break;

                    case HighlightSectorsAtDistanceCommand @event:
                        _signalBus.Fire(@event);
                        break;

                    case TreasureFound @event:
                        _signalBus.Fire(@event);
                        break;

                    case CoinFound @event:
                        _signalBus.Fire(@event);
                        break;

                    case EnergyFound @event:
                        _signalBus.Fire(@event);
                        break;
                }
            }

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