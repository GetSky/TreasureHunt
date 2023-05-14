namespace Features.Sector.Domain
{
    public interface ISectorRepository
    {
        public Sector FindById(string id);
        public void Add(Sector sector);
    }
}