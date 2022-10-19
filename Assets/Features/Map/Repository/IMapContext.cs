namespace Features.Map.Repository
{
    public interface IMapContext
    {
        public void Save(Map map);

        public void Clear();
    }
}