namespace Features.Sector.Repository
{
    public interface ISectorFlasher
    {
        public void Save(Sector sector);

        public void Clear();

        public void Remove(Sector sector);
    }
}