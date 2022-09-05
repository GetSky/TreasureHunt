namespace Features.Sector.Repository
{
    public interface ISectorRepository
    {
        public Sector FindById(string id);
        public Sector FindTreasure();
    }
}