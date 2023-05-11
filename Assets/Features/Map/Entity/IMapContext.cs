namespace Features.Map.Entity
{
    public interface IMapContext
    {
        public void Save(Entity.Map map);

        public void Clear();
    }
}