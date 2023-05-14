using System.Collections.Generic;
using Features.Sector.Domain;

namespace Features.Sector
{
    public class MemoryRepository : ISectorRepository
    {
        private readonly Dictionary<string, Domain.Sector> _sectors = new();

        public Domain.Sector FindById(string id)
        {
            _sectors.TryGetValue(id, out var entity);
            return entity;
        }

        public void Add(Domain.Sector sector)
        {
            _sectors.Add(sector.Id, sector);
        }
    }
}