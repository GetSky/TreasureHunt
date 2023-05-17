using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Features.Sector.Domain;

namespace Features.Sector
{
    public class SectorMemoryRepository : ISectorRepository
    {
        private readonly Dictionary<string, Domain.Sector> _sectors = new();

        public IEnumerable<Domain.Sector> FindAll() => _sectors.Values.ToArray();

        public Domain.Sector FindByXZ(float x, float z)
        {
            _sectors.TryGetValue(
                x.ToString(CultureInfo.InvariantCulture) + z.ToString(CultureInfo.InvariantCulture),
                out var entity
            );
            return entity;
        }

        public Domain.Sector FindById(string id)
        {
            _sectors.TryGetValue(id, out var entity);
            return entity;
        }

        public void Add(Domain.Sector sector) => _sectors.Add(sector.Id, sector);

        public Domain.Sector FindTreasure()
        {
            return _sectors.First(sector => sector.Value.HasTreasure()).Value;
        }

        public void Clear() => _sectors.Clear();
    }
}