using System.Collections.Generic;
using System.Linq;
using Features.Sector.Domain;

namespace Features.Sector
{
    public class SectorMemoryRepository : ISectorRepository
    {
        private readonly Dictionary<string, Domain.Sector> _sectors = new();

        public IEnumerable<Domain.Sector> FindAll() => _sectors.Values.ToArray();

        public Domain.Sector FindById(string id)
        {
            _sectors.TryGetValue(id, out var entity);
            return entity;
        }

        public void Add(Domain.Sector sector)
        {
            _sectors.Add(sector.Id, sector);
        }

        public Domain.Sector FindTreasure()
        {
            return _sectors.First(sector => sector.Value.HasTreasure()).Value;
        }
    }
}