using System.Collections.Generic;

namespace Features.Sector.Domain
{
    public interface ISectorRepository
    {
        public IEnumerable<Sector> FindAll();
        public Sector FindById(string id);
        public void Add(Sector sector);
        Sector FindTreasure();
        void Clear();
    }
}