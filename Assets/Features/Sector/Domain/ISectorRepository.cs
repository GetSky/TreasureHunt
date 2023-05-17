using System.Collections.Generic;

namespace Features.Sector.Domain
{
    public interface ISectorRepository
    {
        public IEnumerable<Sector> FindAll();
        public Sector FindByXZ(float x, float z);
        public Sector FindById(string id);
        public void Add(Sector sector);
        Sector FindTreasure();
        void Clear();
    }
}