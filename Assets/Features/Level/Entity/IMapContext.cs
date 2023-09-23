namespace Features.Level.Entity
{
    public interface IMapContext
    {
        public void Save(Map map);

        public void Clear();
    }
}