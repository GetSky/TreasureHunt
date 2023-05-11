namespace Features.Sector.Repository
{
    public interface ISectorRepository
    {
        public Entities.Sector[] FindAll();
        public Entities.Sector FindById(string id);
        public Entities.Sector FindTreasure();
        public Entities.Sector[] FindInactive();
    }
}