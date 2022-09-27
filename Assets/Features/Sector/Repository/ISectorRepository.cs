namespace Features.Sector.Repository
{
    public interface ISectorRepository
    {
        public Sector[] FindAll();
        public Sector FindById(string id);
        public Sector FindTreasure();
    }
}