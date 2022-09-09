using System.Collections.Generic;
using System.Linq;

namespace Features.Sector.Repository
{
    public class MemorySectorRepository : ISectorRepository, ISectorFlasher
    {
        private readonly Dictionary<string, Sector> _sectors = new Dictionary<string, Sector>();

        public Sector[] FindAll()
        {
            return _sectors.Values.ToArray();
        }

        public Sector FindById(string id)
        {
            _sectors.TryGetValue(id, out var entity);
            return entity;
        }

        public Sector FindTreasure()
        {
            var entity = _sectors.First(sector => sector.Value.Treasure);
            return entity.Value;
        }

        public void Save(Sector sector)
        {
            if (_sectors.ContainsKey(sector.Id)) return;
            _sectors[sector.Id] = sector;
        }

        public void Clear() => _sectors.Clear();
    }
}