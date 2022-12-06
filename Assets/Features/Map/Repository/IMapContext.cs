namespace Features.Map.Repository
{
    public interface IMapContext
    {
        public void Save(Entity.Map map);

        public void Clear();
    }
}