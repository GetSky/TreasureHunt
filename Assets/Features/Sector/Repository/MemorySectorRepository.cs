using System.Collections.Generic;

namespace Features.Sector.Repository
{
    public class MemorySectorRepository : ISectorRepository, ISectorFlasher
    {
        private readonly Dictionary<string, Sector> _sectors = new Dictionary<string, Sector>();

        public Sector FindById(string id)
        {
            _sectors.TryGetValue(id, out var entity);
            return entity;
        }

        public void Save(Sector sector)
        {
            if (_sectors.ContainsKey(sector.Id)) return;
            _sectors[sector.Id] = sector;
        }

        public void Clear() => _sectors.Clear();
    }
}