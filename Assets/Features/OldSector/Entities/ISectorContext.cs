namespace Features.OldSector.Entities
{
    public interface ISectorContext
    {
        public void Save(Sector sector);

        public void Clear();

        public void Remove(Sector sector);
    }
}