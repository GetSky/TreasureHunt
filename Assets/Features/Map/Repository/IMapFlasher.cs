namespace Features.Map.Repository
{
    public interface IMapFlasher
    {
        public void Save(Map map);

        public void Clear();
    }
}